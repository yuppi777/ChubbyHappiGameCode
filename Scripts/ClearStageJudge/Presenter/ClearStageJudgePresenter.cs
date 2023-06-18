using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;

public class ClearStageJudgePresenter : MonoBehaviour
{
    [Inject]
    IGameData gameData;

    [SerializeField]
    ClearStageJudgeView judgeView;
    void Start()
    {
        Oninitialize();
        
    }

    
    private void Oninitialize()
    {
        judgeView.Juge(gameData.isClear, gameData.clearRange);
    }


}
