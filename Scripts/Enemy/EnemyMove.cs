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
    [Header("���̃L�����ɂ��Ă���v���C���[���G�X�N���v�g")]
    private Enemy_PlayerSarch playerSarch;

    private NavMeshAgent agent;

    private bool isChasing;//�v���C���[��ǐՃt���O

    [SerializeField]
    private float speed;

    [SerializeField]
    [Header("�_���[�W")]
    private int damage;

    [SerializeField]
    [Header("�U���J�n�̋���")]
    private float attackRange = 2f;

    [SerializeField]
    [Header("�U���̃^�C�����~�b�g")]
    private float TimeRange = 30f;

    private bool isAttacking = true;//�U�����ł��邩�ۂ�

    private Animator animator;

    [SerializeField]
    [Header("���񂾎��ɏo��p�[�e�B�N��")]
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
                  //Debug.Log("�U���͈�");
                  //isAttacking = true;
                  
                 
              }
              if (distance < attackRange && isAttacking == true)
              {
                  
                  Debug.Log("�U��");
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
        //Debug.Log("�^�C�����~�b�g�X�^�[�g");
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
    /// �v���C���[��ǂ������邩�ۂ�
    /// </summary>
    private void Chasinng()
    {
        if (isChasing)
        {

            agent.SetDestination(player.position);
        }

    }
    

    // <summary>
    // DeathAnimation�J�n���ɌĂ΂��
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
    /// DeathAnimation�I�����ɌĂ΂��
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