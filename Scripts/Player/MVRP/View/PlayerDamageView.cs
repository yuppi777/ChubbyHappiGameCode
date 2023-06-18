using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageView : MonoBehaviour
{
    private int _playerHp;
 

    public void SetHp(int MaxHp)
    {
        _playerHp = MaxHp;
    }

    public void Damage(int damage)
    {
        _playerHp -= damage;
    }

}
