using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

public class GameClearJudge : MonoBehaviour
{

  public  List<EnemyMove> Enemys = new List<EnemyMove>();

    [SerializeField]
    private PlayerMove playerMove;

    public static bool gameClea = false;
    public static int cleaRange = 0;



    private void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < Enemys.Count; i++)
        {
            //Debug.Log(Enemys[i]);
            if (Enemys[i] == null)
            {
                Enemys.Remove(Enemys[i]);
            }
        }

        if (Enemys.Count <= 0)
        {
            playerMove.AnLookCus();
            cleaRange++;
            gameClea = true;
            SceneManagement.Instance.SceneChange("GameClea");
        }
        
      
    }
}
