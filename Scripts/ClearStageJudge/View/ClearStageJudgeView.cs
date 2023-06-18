using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearStageJudgeView : MonoBehaviour
{
    [SerializeField]
    private  List<Button> buttons;
   



    public void Juge(bool isclear,int clearrange)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (clearrange >= i)
            {
                buttons[i].interactable = true;
            }
        }
    }
}
