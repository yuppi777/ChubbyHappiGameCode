using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotateView : MonoBehaviour
{
    IPlayerData playerData = new PlayerData();
    void Start()
    {
        
    }
    public void MoveCamera( float x_sensi)
    {
        float x_Rotation = Input.GetAxis("Mouse X");
        x_Rotation = x_Rotation * x_sensi;
        this.transform.Rotate(0, x_Rotation, 0);
        
    }

}
