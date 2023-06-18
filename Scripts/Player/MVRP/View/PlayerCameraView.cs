using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraView : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }
    public void MoveCamera(float y_sensi)
    {
       
        float y_Rotation = Input.GetAxis("Mouse Y");
        y_Rotation = y_Rotation * y_sensi;
        _camera.transform.Rotate(-y_Rotation, 0, 0);


    }
}
