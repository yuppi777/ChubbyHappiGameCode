using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameData 
{
    public List<int> anLookStages { get; set; }
    public int clearRange { get; set; }
    public bool isClear { get; set; }
    public int deathTransForm_Y { get;  }
   

}
