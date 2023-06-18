using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnyKey : MonoBehaviour
{
    

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManagement.Instance.SceneChange("Titol");
        }
    }

}
