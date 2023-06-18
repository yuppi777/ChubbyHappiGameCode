using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveView : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }
    public void Movement(float speed)
    {

        var V = Input.GetAxis("Vertical");
        var H = Input.GetAxis("Horizontal");
      var moving = H * transform.right + V * transform.forward;
        rb.AddForce(moving * speed* Time.deltaTime);

    }
   
   
}
