using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;


public class EnemyPresenter : MonoBehaviour
{
    [Inject]
    IUseCase useCase;

    [Inject]
    IEnemyData enemyData;

    [SerializeField]
    EnemyMoveView moveView;

    [SerializeField]
    EnemyAnimationView animationView;

    [SerializeField]
    EnemyLevelView levelView;

    EnemyModel enemyModel = new EnemyModel();


    
    void Start()
    {
        OnInitialize();

       
    }

   void OnInitialize()
    {
        enemyData.EnemiesAdd();
        enemyModel.SetEnemyType(levelView.EnemyType);
        enemyModel.SetEnemyReceiveDamage();

        Observable.EveryFixedUpdate().Subscribe(_ => {
            moveView.Chasinng(enemyModel.IsCashing, useCase.GetTransForm());
            enemyModel.DistanceCheck(this.transform,useCase.GetTransForm());
            enemyModel.OnAttack();
            //animationView.isAttack(enemyModel.IsAttacking);
            
        }).AddTo(this);

        enemyModel.ObserveEveryValueChanged(value => value.IsAttacking)
            .DistinctUntilChanged()
            .Where(value=> value== false)
            .Subscribe(value =>
            {
                useCase.Damage(enemyModel.Damage);
               
                //animationView.isAttack(value);
            })
            .AddTo(this);

        enemyModel.ObserveEveryValueChanged(value => value.IsAttacking)
            //.DistinctUntilChanged()
            .Subscribe(value =>
            {
                
                animationView.isAttack(enemyModel.IsAttacking);
                
            })
            .AddTo(this);

        enemyModel.ObserveEveryValueChanged(value => value.IsCashing)
            .DistinctUntilChanged()
            .Subscribe(value =>
            {
                animationView.isPlayerLook(value);
            })
            .AddTo(this);
        enemyModel.ObserveEveryValueChanged(value => value.EnemyHp)
            .DistinctUntilChanged()
            .Subscribe(value =>
            {
                if (value <= 0)
                {
                    animationView.isEnemyDeath();
                }
            })
            .AddTo(this);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            enemyModel.EnemyDamage(enemyModel.ReceiveDamage);
            animationView.DamageParticle();
        }
    }
    private void OnDestroy()
    {
       
        enemyData.EnemiesRemove();
    }
}
