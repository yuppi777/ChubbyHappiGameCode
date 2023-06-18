using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class PlayerText : MonoBehaviour
{
    [SerializeField]
    [Header("HPを出すテキスト")]
    private Text _hpText;

    [SerializeField]
    [Header("プレイヤーについてるPlayerMoveスクリプト")]
    private PlayerMove player;


    private void Start()
    {
        HpTextUp(player);
    }


    public void HpTextUp(PlayerMove playerMove)
    {
        playerMove.ObserveEveryValueChanged(playerMove => playerMove.Hp)
            .Subscribe(value => 
            {

                _hpText.text = "HP" +playerMove.Hp.ToString();
            })
            .AddTo(this);
    }






}
