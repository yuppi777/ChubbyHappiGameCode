using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverView : MonoBehaviour
{

    public void GameOverScene()
    {
        SceneManagement.Instance.SceneChange("GameOver");
    }

}
