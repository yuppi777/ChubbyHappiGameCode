using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOmu : MonoBehaviour
{
    [SerializeField]
    DOAnimationManager animationManager;

    [SerializeField]
    [Header("‰ñ‚é‘¬“x")]
    private float speed;

    [SerializeField]
    private Vector3 vector3;


    private void Start()
    {
        animationManager.DORotateObject(this.gameObject,speed,vector3);
    }

}
