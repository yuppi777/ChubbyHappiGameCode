using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class EnemyModel 
{
    public bool IsCashing { get=>isCashing; set=>isCashing=value; }
    public float AttackRange { get => attackRange; }
    public int Damage { get => damage; }
    public bool IsAttacking { get => isAttacking;  }
    public int maxEnemyHp { get => MAXENEMYHP; }
    public int EnemyHp { get => enemyHp; set => enemyHp = value; }
    public int ReceiveDamage { get => receiveDamage; set => receiveDamage = value; }
    public enum ENEMY_TYPE
    {
        Level1,
        Level2,
        Level3,
    }


    private ENEMY_TYPE EnemyType;
    


    private const int MAXENEMYHP = 100;

    private float distanceMax = 10; //メートル単位
    private float attackRange = 2f;
    private bool isCashing = false;
    private bool isAttacking = true;
    private int damage = 5;
    private float timeRange = 2f;
    private float distance;
    private int enemyHp = MAXENEMYHP;
    private int receiveDamage;
    

    public void DistanceCheck(Transform enemytransform,Transform playertransform)
    {

         distance = Vector3.Distance(enemytransform.position, playertransform.position);
        if (distance<distanceMax && isAttacking == true)
        {
            isCashing = true;
        }
        else
        {
            //isCashing = false; //離れたときに追跡をやめる処理
        }
    }

    public void SetEnemyType(ENEMY_TYPE TYPE)
    {
        EnemyType = TYPE;
        
    }
    public void SetEnemyReceiveDamage()
    {
        switch (EnemyType)
        {
            case ENEMY_TYPE.Level1:
                receiveDamage = 100;
                break;
            case ENEMY_TYPE.Level2:
                receiveDamage = 50;
                break;
            case ENEMY_TYPE.Level3:
                receiveDamage = 10;
                    break;
            default:
                break;
        }
    }
    
    public void OnAttack()
    {
        if (distance < attackRange && isAttacking == true)
        {
            
            isCashing = false;
            isAttacking = false;
            DelayTime();
            Debug.Log(isCashing+"まん");
        }
    }

    public void EnemyDamage(int damage)
    {
        enemyHp -= damage;
        isCashing = true; //攻撃を受けたらプレイヤーを追いかける
    }

    async void DelayTime()
    {
        await Task.Delay((int)timeRange * 1000);
        isAttacking = true;
        isCashing = true;
    }
}
