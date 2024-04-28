using System.Collections;
using System.Collections.Generic;
using Megumin.GameSystem;
using UnityEngine;


public class KingDialogueSystem : MonoBehaviour
{
    public DialogueTrigger king;

    private void Start()
    {
        if(StageHandlerGlobal.instance.isKingSpeakOver)
            Choice();
    }

    private void Update()
    {
        if(DialogueTagDetector.instance.IsTagExist("mission", "defeat_boss"))
        {
            StageHandlerGlobal.instance.stage = Megumin.GameSystem.Stage.MEET_PARTNER;
            StageHandlerGlobal.instance.flowerMissionStage = FlowerMissionStage.OPEN;
            StageHandlerGlobal.instance.isKingSpeakOver = true;
            Choice();
        }
    }

    private void Choice()
    {
        king.knotName = "mission_proceed_1";
    }
}
