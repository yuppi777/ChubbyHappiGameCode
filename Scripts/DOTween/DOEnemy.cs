using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOEnemy : MonoBehaviour
{

    [SerializeField]
    [Header("��]�X�s�[�h")]
    private float rotateSpeed;

    [SerializeField]
    [Header("�ړ��X�s�[�h")]
    private float moveSpeed;
        
    void Start()
    {
        DORotateMove();
        DOMove();
    }


    private void DORotateMove()
    {
        //this.gameObject.transform.localRotation = Quaternion.identity;
        this.gameObject.transform.DOLocalRotate(new Vector3(0.0f, 0.0f, 360.0f), rotateSpeed)
                                 .SetRelative(true)
                                 .SetEase(Ease.InOutQuad)
                                 .SetLoops(-1,LoopType.Restart)
                                 .SetLink(this.gameObject);
    }
   
    private void DOMove()
    {
        this.gameObject.transform.DOLocalMoveX(105, moveSpeed);
    }
     
    
}
