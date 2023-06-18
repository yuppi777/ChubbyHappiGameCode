using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UniRx;
using UniRx.Triggers;
using System;

public class EnemyMove : MonoBehaviour,IEnemy
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private PlayerMove playerMove;

    [SerializeField]
    [Header("このキャラについているプレイヤー索敵スクリプト")]
    private Enemy_PlayerSarch playerSarch;

    private NavMeshAgent agent;

    private bool isChasing;//プレイヤーを追跡フラグ

    [SerializeField]
    private float speed;

    [SerializeField]
    [Header("ダメージ")]
    private int damage;

    [SerializeField]
    [Header("攻撃開始の距離")]
    private float attackRange = 2f;

    [SerializeField]
    [Header("攻撃のタイムリミット")]
    private float TimeRange = 30f;

    private bool isAttacking = true;//攻撃中であるか否か

    private Animator animator;

    [SerializeField]
    [Header("死んだ時に出るパーティクル")]
    private GameObject particlePrefab;

    public void Move()
    {
        
    }

    void Start()
    {
        animator = this.GetComponent<Animator>();
        agent = this.gameObject.GetComponent<NavMeshAgent>();


        isChasing = false;
        //animator.SetBool("isPlayerLook", false);
        TrueIsChasing(playerSarch);

        this.FixedUpdateAsObservable()
          .Subscribe(_ =>
          {
              Chasinng();
              float distance = Vector3.Distance(transform.position, player.position);

              if (distance < attackRange)
              {
                  //Debug.Log("攻撃範囲");
                  //isAttacking = true;
                  
                 
              }
              if (distance < attackRange && isAttacking == true)
              {
                  
                  Debug.Log("攻撃");
                  StartCoroutine(TimeLimit());
                  isChasing = false;

                  AttackPlayer();
                  animator.SetBool("isAttack", true);
                  animator.SetBool("isPlayerLook", false);
                  isAttacking = false;
                  
                  


              }
              else if (!isAttacking)
              {
                  //AttackPlayer();
                  TrueIsChasing(playerSarch);
                  //isAttacking = false;
                  
              }

              if (distance > attackRange)
              {
                  //isChasing = false;
                  animator.SetBool("isAttack", false);
              }
          })
          .AddTo(this);

    }

    IEnumerator TimeLimit()
    {
        isAttacking = false;
        //Debug.Log("タイムリミットスタート");
       yield return new WaitForSeconds(TimeRange);
        isAttacking = true;
    }


    private void TrueIsChasing(Enemy_PlayerSarch playerSarch)
    {
        playerSarch.ObserveEveryValueChanged(playerSarch =>playerSarch.PlayerOn)
            .Subscribe(value =>
            {
                 isChasing = value;
                animator.SetBool("isPlayerLook", value);
               

            })
            .AddTo(gameObject);

    }
 
 
    
    /// <summary>
    /// プレイヤーを追いかけるか否か
    /// </summary>
    private void Chasinng()
    {
        if (isChasing)
        {

            agent.SetDestination(player.position);
        }

    }
    

    // <summary>
    // DeathAnimation開始時に呼ばれる
    // </summary>
    public void DeathAnimationPlay()
    {
        AudioManager.Instance.PlaySE("Recovery");
        playerSarch = null;
        isChasing = false;

        GameObject par;
        par = Instantiate(particlePrefab, this.transform.position, Quaternion.identity);
        par.transform.parent = this.transform;


    }
    /// <summary>
    /// DeathAnimation終了時に呼ばれる
    /// </summary>
    public void DeathAnimationEnd()
    {
        AudioManager.Instance.PlaySE("Down");
        Destroy(this.gameObject);
    }


    private void AttackPlayer()
    {
        
        playerMove.Hp -= damage;
        
        
        if (playerMove.Hp <0)
        {
            playerMove.AnLookCus();
            SceneManagement.Instance.SceneChange("GameOver");
        }
        Debug.Log(playerMove.Hp);
    }



    
}