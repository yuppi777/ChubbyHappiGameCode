using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimationView : MonoBehaviour
{
    private Animator animator;

    [SerializeField]
    [Header("死んだ時に出るパーティクル")]
    private GameObject particlePrefab; //のちのちParticleSystemに変更

    [SerializeField]
    [Header("ダメージを食らった時に出るパーティクル")]
    private GameObject damageParticlePrefab;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        //animator = GetComponent<Animator>();   
    }
    /// <summary>
    /// DeathAnimation開始時に呼ばれる
    /// </summary>
    public void DeathAnimationPlay()
    {
       NavMeshAgent agent = this.gameObject.GetComponent<NavMeshAgent>();
        agent .updatePosition = false;
        agent.updateRotation = false;
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

    public void isAttack(bool isattack)
    {
        animator.SetBool("isAttack", isattack);
        
    }

    public void isPlayerLook(bool isplayerLook)
    {
        animator.SetBool("isPlayerLook", isplayerLook);
    }

    public void isEnemyDeath()
    {
        animator.SetTrigger("Death");
    }
    public void DamageParticle()
    {
        GameObject par;
        par = Instantiate(damageParticlePrefab, this.transform.position, Quaternion.identity);
        par.transform.parent = this.transform;
          
    }


}
