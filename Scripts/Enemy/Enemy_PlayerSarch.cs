using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_PlayerSarch : MonoBehaviour
{
    [SerializeField]
    [Header("ƒvƒŒƒCƒ„[‚ªõ“G”ÍˆÍ‚É“ü‚Á‚½‚©‚Ç‚¤‚©")]
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
            //Debug.Log("P‚Î‚ê‚½");
        }
        //Debug.Log("ŒÄ‚Î‚ê‚½");
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //playerOn = false;
           
        }
    }

}
