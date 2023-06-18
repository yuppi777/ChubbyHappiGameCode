using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyData 
{
  
    public int maxEnemies { get; set; }  
    public int enemies { get; set; }


    public void MaxEnemiesInitialize(int enemies);
    public void EnemiesAdd();
    public void EnemiesRemove();
}
