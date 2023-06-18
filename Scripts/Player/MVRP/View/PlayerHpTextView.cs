using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpTextView : MonoBehaviour
{
    [SerializeField]
    private Text playerHpText;
    

    public void PlayerHpText(int hp)
    {
        playerHpText.text = "HP"+hp.ToString();
    }
}
