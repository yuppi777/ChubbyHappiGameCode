using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BulletsPresenter : MonoBehaviour
{
    [SerializeField] 
    GunControll gunControll;

    [SerializeField] 
    BulletCountView countView;

    [SerializeField] 
    DOAnimationManager textAnimation;


    private void Start()
    {
        textAnimation.DOFadeTextInitialize(countView.reloadText);

        gunControll.ObserveEveryValueChanged(value => value.NumBullet)
                   .DistinctUntilChanged()
                   .Subscribe(value =>
                   {
                       countView.SetBulletCount(value);

                       if (value == 0)
                       {
                           countView.reloadText.gameObject.SetActive(true);
                           textAnimation.DOFadeTextInitialize(countView.reloadText);
                           textAnimation.DOFadeTextLoop(countView.reloadText, countView.ReloadFadeSpeed);
                           textAnimation.DOTweenerSet();

                       }
                       if (value > 0)
                       {
                           countView.reloadText.gameObject.SetActive(false);
                       }


                       //if (gunControll.IsOutOfAmmo == true)
                       //{
                       //    countView.reloadText.gameObject.SetActive(true);
                       //}
                       //if (gunControll.IsOutOfAmmo == false)
                       //{
                       //    countView.reloadText.gameObject.SetActive(false);
                       //    //textAnimation.DOLoopEnd();
                       //}


                   })
                   .AddTo(this);
    }






}
