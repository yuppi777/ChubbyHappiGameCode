using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    private Rigidbody _thisBulletRb;

    [SerializeField]
    private float speed;

    [SerializeField]
    [Header("�e��������܂ł̎���")]
    private float destime = 30;

    private Animator enemyAnimator;//�G�̃A�j���[�^�[���i�[����

    

    private void Awake()
    {
        
        try
        {
           _thisBulletRb = this.gameObject.GetComponent<Rigidbody>();
        }
        catch (System.Exception)
        {
            this.gameObject.AddComponent<Rigidbody>();
            _thisBulletRb = this.gameObject.GetComponent<Rigidbody>();
        }   
    }
    void Start()
    {
        BulletAddForce();
        StartCoroutine(DestroyBullet());
    }


    private void BulletAddForce()
    {
        _thisBulletRb.AddForce(this.gameObject.transform.forward * speed );
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag  =="Enemy" )
        {
           
            //Debug.Log("�G�ɐG�ꂽ");
            enemyAnimator = collision.gameObject.GetComponent<Animator>();
            //enemyAnimator.SetTrigger("Death");
            //Destroy(collision.gameObject);//�G���f�X�g���C
            Destroy(this.gameObject);//�e���g���f�X�g���C
        }
    }
    void Update()
    {
        if (this.transform.position.y <= -20)
        {
 
            Destroy(this);
        }
    }

    IEnumerator DestroyBullet()
    {

        yield return new WaitForSeconds(destime);
        Destroy(this.gameObject);
    }
}
