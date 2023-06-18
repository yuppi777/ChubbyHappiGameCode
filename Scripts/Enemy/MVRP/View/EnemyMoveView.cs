using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveView : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    public void Chasinng(bool isChasing,Transform player)
    {
        if (isChasing)
        {

            agent.SetDestination(player.position);
        }
        else
        {
            
            Debug.Log("í«ê’Ç‚Çﬂ");
        }
        
    }
}
