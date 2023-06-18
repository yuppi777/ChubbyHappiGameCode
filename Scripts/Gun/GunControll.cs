using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GunControll : MonoBehaviour
{
    [SerializeField]
    [Header("’e")]
    private GameObject bulletprefab;

    [SerializeField]
    [Header("eŒû")]
    private Transform shotArea;

    
   

    //[SerializeField]
    [Header("’e‚Ì‘•“U”")]
    private const int NUMBULLET = 5;


    [Header("’e‚Ì¡‚Ì‘•“U”")]
    private int _numBullet = NUMBULLET;

    private bool isNowReload  = false ;

    [SerializeField]
    [Header("ƒŠƒ[ƒh‚ÌƒN[ƒ‹ƒ^ƒCƒ€")]
    private float reLoadCoolTime;

    private Rigidbody bulletRb;

    private bool isOutOfAmmo = false;

    public int NumBullet { get => _numBullet; }
    public bool IsOutOfAmmo { get => isOutOfAmmo;  }

    void Start()
    {
        

    }
   

    private void BulletShot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _numBullet>0 )
        {
            AudioManager.Instance.PlaySE("shot");
          GameObject prefab= Instantiate(bulletprefab, shotArea.position, Quaternion.identity);
            //prefab.transform.Rotate(-90, 0, 0);
            prefab.transform.Rotate(Camera.main.transform.eulerAngles);

            _numBullet--;
        }
        if (_numBullet < 0) isOutOfAmmo = true;
       
    }

    private void Reload()
    {
       
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isNowReload == false)
            {
                _numBullet = NUMBULLET;
                isOutOfAmmo = true;
                AudioManager.Instance.PlaySE("Reload");
                StartCoroutine(ReloadCool());
                
            }
        }
    }


    IEnumerator ReloadCool()
    {

        isNowReload = true;
        yield return new WaitForSeconds(reLoadCoolTime);
        isNowReload = false;
    }

    // Update is called once per frame
    void Update()
    {
        BulletShot();
        Reload();
    }
}
