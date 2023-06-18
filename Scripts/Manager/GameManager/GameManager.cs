using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;


public class GameManager : MonoBehaviour
{
    [Inject]
    IUseCase useCase;

    [Inject]
    IEnemyData enemyData;

    [Inject]
    IGameData gameData;

    [SerializeField]
    GameClearView clearView;

    [SerializeField]
    GameOverView gameOverView;

    [SerializeField]
    CusLook cusLook;

    private void Start()
    {
        OnInitialize();
    }

    private void OnInitialize()
    {
        //UseCase.isClear = false;
        gameData.isClear = false;

        Observable.EveryUpdate().Subscribe(_ => {
            //enemyData.maxEnemies();
            //Debug.Log(UseCase.clearRange+"‹¾");
            if (useCase.GetTransForm().position.y < gameData.deathTransForm_Y)
            {
                cusLook.AnLookCus();
                gameOverView.GameOverScene();
                
            }
        }).AddTo(this);


        enemyData.ObserveEveryValueChanged(value => value.enemies)
            .Skip(1)
            .DistinctUntilChanged()
            //.Where(value => value >0 )
            .Subscribe(value =>
            {
                if (enemyData.enemies <= 0)
                {
                    gameData.clearRange = clearView.GetClearRange();
                    gameData.isClear = true;
                    cusLook.AnLookCus();
                    clearView.GameCleaScene();
                }
            })
            .AddTo(this);

        useCase.ObserveEveryValueChanged(value => value.hp)
            .DistinctUntilChanged()
            .Subscribe(value =>
            {
                if (useCase.hp <= 0)
                {
                    cusLook.AnLookCus();
                    gameOverView.GameOverScene();
           
                }
            })
            .AddTo(this);

      

    }

 

}
