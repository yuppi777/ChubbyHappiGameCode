using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CusLook : MonoBehaviour
{

    public void LookCus()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void AnLookCus()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
