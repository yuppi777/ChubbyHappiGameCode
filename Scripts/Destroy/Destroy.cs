using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField]
   private PlayerMove playerMove;

    [SerializeField]
    private GameObject player;
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Player")
        //{
        //    playerMove.AnLookCus();
        //    SceneManagement.Instance.SceneChange("GameOver");
        //}
        Destroy(collision.gameObject);
        
    }
    private void Update()
    {
        if (player.transform.position.y <= -20)
        {
            playerMove.AnLookCus();
            SceneManagement.Instance.SceneChange("GameOver");
            Destroy(player);
        }
    }
}
