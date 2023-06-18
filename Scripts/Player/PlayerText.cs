using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class PlayerText : MonoBehaviour
{
    [SerializeField]
    [Header("HP���o���e�L�X�g")]
    private Text _hpText;

    [SerializeField]
    [Header("�v���C���[�ɂ��Ă�PlayerMove�X�N���v�g")]
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
