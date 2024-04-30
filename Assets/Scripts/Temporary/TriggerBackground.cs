using System.Collections;
using System.Collections.Generic;
using Megumin.GameSystem;
using UnityEngine;

public class TriggerBackground : MonoBehaviour
{
    public string background_audio;
    public bool isTrigger;

    void Start()
    {
        if(isTrigger)
        {
            if(!StageHandlerGlobal.instance.isFirstBattleOver)
                AudioManager.instance.Play(background_audio);    
            return;
        }
        AudioManager.instance.Play(background_audio);    
    }
}
