using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearView : MonoBehaviour
{
    [SerializeField]
    private int clearRange;

    public int GetClearRange() { return clearRange; }



  
    public void GameCleaScene()
    {        
        
            SceneManagement.Instance.SceneChange("GameClea");
        
    }
}
