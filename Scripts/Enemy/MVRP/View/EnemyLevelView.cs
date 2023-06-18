using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevelView : MonoBehaviour
{
    [SerializeField]
   private EnemyModel.ENEMY_TYPE enemyType;

    public EnemyModel.ENEMY_TYPE EnemyType { get => enemyType;  }

    
}
