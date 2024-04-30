using System.Collections;
using System.Collections.Generic;
using Megumin.GameSystem;
using UnityEngine;

public class StageHandlerGlobal : MonoBehaviour
{
    public static StageHandlerGlobal instance{get; private set;}
    
    [Tooltip("Handle what the stage is in current.")]
    public Stage stage;
    public FlowerMissionStage flowerMissionStage;
    
    public bool isCompleteBattleFirst;
    
    public bool isKingSpeakOver;

    public bool isFirstBattleOver;
    public bool isFirstShockOver;

    public int health = 10;

    public void Awake()
    {
        if(instance != null)
            return;
        instance = this;
    }

    public void Init()
    {
        stage = Stage.FIRST_START;
        flowerMissionStage = FlowerMissionStage.LOCKED;
        isCompleteBattleFirst = false;
        isKingSpeakOver = false;
        isFirstBattleOver = false;
        isFirstShockOver = false;
        health = 10;
    }
}
