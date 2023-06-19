using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : IGameData
{
    private static int ClearRange = 0;
    private static bool IsClear = false;
    private const int DEATH_TRANSFORM_Y = -5;
    private static List<int> AnLookStages = new List<int>();

    public List<int> anLookStages { get => AnLookStages; set=>AnLookStages =value; }
    public int clearRange { get => ClearRange; set => ClearRange = value; }
    public bool isClear { get => IsClear; set => IsClear = value; }
    public int deathTransForm_Y { get => DEATH_TRANSFORM_Y; }
}
