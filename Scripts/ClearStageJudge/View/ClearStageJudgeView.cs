using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearStageJudgeView : MonoBehaviour
{
    [SerializeField]
    private  List<Button> buttons;

   

    public void AnLookChack(List<int> clearrranges)
    {
        if (clearrranges == null)
        {
            return;
        }
        if (buttons.Count > clearrranges.Count)
        {
            return;
        }
      
        foreach (int item in clearrranges)
        {
           
            buttons[item].interactable = true;
        }
    }
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
