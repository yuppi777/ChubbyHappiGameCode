using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCase : IUseCase
{
    IPlayerData playerData = default;

   
    
    public float speed { get { return playerData.speed; } }
    public float x_sensi { get {return playerData.x_sensi; } }
    public float y_sensi { get {return playerData.y_sensi; } }
    public int maxHp { get { return playerData.maxHp; } }
    public int hp { get { return playerData.hp; } }

   

    public UseCase(IPlayerData Data)
    {
        playerData = Data;
    } 

    public Transform GetTransForm()
    {
        return playerData.PlayerTransform;
    } 

    public void SetTransForm(Transform transform)
    {
       playerData.PlayerTransform = transform;
    }

    public void Damage(int damage)
    {
        playerData.hp -= damage;
    }
}
