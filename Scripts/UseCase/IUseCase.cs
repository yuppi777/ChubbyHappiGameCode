using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUseCase 
{
    public float speed { get; }
    public float x_sensi { get; }
    public float y_sensi { get; }
    public int maxHp { get; }
    public int hp { get; }

  



    public Transform GetTransForm();
    public void SetTransForm(Transform transform);
    public void Damage(int damage);
}
