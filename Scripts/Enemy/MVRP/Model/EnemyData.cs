using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : IEnemyData
{

    private int MaxEnemies;
    private int Enemies;

    public int maxEnemies { get => MaxEnemies; set => MaxEnemies = value; }
    public int enemies { get => Enemies; set => Enemies = value; }


    public void MaxEnemiesInitialize(int enemies)
    {
        maxEnemies = enemies;
    }
    public void EnemiesAdd()
    {
        enemies++;
    }
    public void EnemiesRemove()
    {
        enemies--;
    }

}
