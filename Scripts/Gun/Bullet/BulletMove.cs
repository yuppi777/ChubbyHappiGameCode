using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    private Rigidbody _thisBulletRb;

    [SerializeField]
    private float speed;

    [SerializeField]
    [Header("弾が消えるまでの時間")]
    private float destime = 30;

    private Animator enemyAnimator;//敵のアニメーターを格納する

    

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
           
            //Debug.Log("敵に触れた");
            enemyAnimator = collision.gameObject.GetComponent<Animator>();
            //enemyAnimator.SetTrigger("Death");
            //Destroy(collision.gameObject);//敵をデストロイ
            Destroy(this.gameObject);//弾自身をデストロイ
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
