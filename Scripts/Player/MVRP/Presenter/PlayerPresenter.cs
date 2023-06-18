using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;

public class PlayerPresenter : MonoBehaviour
{
    [Inject]
    IUseCase useCase;
    
    [SerializeField]
    PlayerMoveView moveView;

    [SerializeField]
    PlayerCameraView cameraView;

    [SerializeField]
    PlayerRotateView rotateView;

    [SerializeField]
    PlayerDamageView damageView;

    [SerializeField]
    PlayerHpTextView textView;

    [SerializeField]
    CusLook cusLook;

    private void Awake()
    {
        useCase.SetTransForm(this.transform);
    }
    private void Start()
    {
        OnInitialize();
    }

    private void OnInitialize()
    {
        Observable.EveryUpdate().Subscribe(_ => {
            
            moveView.Movement(useCase.speed);
            cameraView.MoveCamera(useCase.y_sensi);
            rotateView.MoveCamera(useCase.x_sensi);
        }).AddTo(this);


        damageView.SetHp(useCase.maxHp);
        cusLook.LookCus();

       useCase.ObserveEveryValueChanged(value => value.hp)
           .DistinctUntilChanged()
           //.Where(value => value >0 )
           .Subscribe(value =>
           {
               textView.PlayerHpText(value);

           })
           .AddTo(this);
    }




}
