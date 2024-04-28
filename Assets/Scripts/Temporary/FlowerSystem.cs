using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Megumin.GameSystem;
using UnityEngine;


public class FlowerSystem : MonoBehaviour
{
    [SerializeField] public GameObject flowerPerson;
    private DialogueTrigger dialogueTrigger;

    private void Start()
    {
        dialogueTrigger = flowerPerson.GetComponent<DialogueTrigger>();
        Choise();
    }

    private void Update()
    {
        if(DialogueTagDetector.instance.IsTagExist("mission", "get_flower"))
        {
            StageHandlerGlobal.instance.flowerMissionStage = FlowerMissionStage.PROCEED;
            Choise();
        }

        
    }

    private void Choise()
    {
        switch(StageHandlerGlobal.instance.flowerMissionStage)
        {
            case FlowerMissionStage.LOCKED:
                dialogueTrigger.knotName = "go_castle";
                break;
            case FlowerMissionStage.OPEN:
                dialogueTrigger.knotName = "help_1";
                break;
            case FlowerMissionStage.PROCEED:
                dialogueTrigger.knotName = "mission_1";
                break;
            case FlowerMissionStage.COMPLETE:
                dialogueTrigger.knotName = "mission_1_complete";
                break;
            case FlowerMissionStage.FINISH:
                dialogueTrigger.knotName = "mission_1_finish";
                break;
        }
    }

    
}
