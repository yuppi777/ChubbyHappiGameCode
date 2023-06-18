using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearStageJudge : MonoBehaviour
{

    [SerializeField]
    [Header("ステージ1のボタン")]
    private Button button1;

    [SerializeField]
    private Button button2;

    [SerializeField]
    private Button button3;

    private void Awake()
    {
        button2.interactable = false;
        button3.interactable = false;
    }

    void Start()
    {
        Juge();
    }



    private void Juge()
    {
        //if (UseCase.isClear == true)
        //{
        //    button2.interactable = true;
        //    if (button2.interactable == true && UseCase.clearRange > 1)
        //    {
        //        button3.interactable = true;
        //    }
        //}

    }

   
}
