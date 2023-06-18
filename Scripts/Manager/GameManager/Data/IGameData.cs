using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameData 
{
    public int clearRange { get; set; }
    public bool isClear { get; set; }
    public int deathTransForm_Y { get;  }

}
