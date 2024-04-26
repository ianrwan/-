using System.Collections;
using System.Collections.Generic;
using Megumin.GameSystem;
using Unity.VisualScripting;
using UnityEngine;

public abstract class SpecialEventsControl : MonoBehaviour
{
    protected abstract void StartEvent();
    protected abstract void DetectEvent();
    protected abstract void EndEvent();

    public static bool isSpecialEventStart{get; private set;}

    [Header("Set Trigger")]
    [Tooltip("Check if the SpecialEvent will trigger on start.")]
    public bool isStartTrigger;

    [Tooltip("Input when should trigger the SpecialEvent.")]
    public Stage triggerStage;

    [Header("End Change")]
    [Tooltip("Change the stage after SpecilaEvent end.")]
    public bool isEndChangeStage;

    [Tooltip("Change the stage when end trigger.")]
    public Stage nextStage;

    private void Start()
    {
        isSpecialEventStart = false;

        if(triggerStage != StageHandlerGlobal.instance.stage)
            return;
        Debug.Log("in");
        if(isStartTrigger)
            SetUp();
    }

    private void Update()
    {
        if(isSpecialEventStart == true)
            DetectEvent();
    }

    public void SetUp()
    {
        StartEvent();
        isSpecialEventStart = true;
    }

    public void EndSpecialEvent()
    {
        isSpecialEventStart = false;

        if(isEndChangeStage == true)
        {
            StageHandlerGlobal.instance.stage = nextStage;
        }

        EndEvent();
    }
}
