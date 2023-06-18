using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerData 
{
   public float speed { get; }
   public float x_sensi { get; }
   public float y_sensi { get; }
   public int maxHp { get; }
   public Transform PlayerTransform { get; set; }
   public int hp { get; set; }

}
