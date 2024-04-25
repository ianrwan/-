using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class SpecialEventsControl : MonoBehaviour
{
    protected abstract void StartEvent();
    protected abstract void DetectEvent();

    public static bool isSpecialEventStart{get; private set;}
    public bool isStartTrigger;

    private void Start()
    {
        isSpecialEventStart = false;

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
    }
}
