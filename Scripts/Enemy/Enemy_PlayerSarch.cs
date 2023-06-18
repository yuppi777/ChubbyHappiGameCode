using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_PlayerSarch : MonoBehaviour
{
    [SerializeField]
    [Header("�v���C���[�����G�͈͂ɓ��������ǂ���")]
    private bool playerOn;

    public bool PlayerOn { get => playerOn;  }

    private void Start()
    {
        playerOn = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOn = true;
            //Debug.Log("P�΂ꂽ");
        }
        //Debug.Log("�Ă΂ꂽ");
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //playerOn = false;
           
        }
    }

}
