using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSystemFromCastle : MonoBehaviour
{
    [SerializeField] public GameObject[] flowers;
    private DialogueTrigger[] dialogueTrigger;

    private void Start()
    {
        dialogueTrigger = new DialogueTrigger[flowers.Length];

        int index = 0;
        foreach(var flower in flowers)
        {
            dialogueTrigger[index] = flower.GetComponent<DialogueTrigger>();
            Debug.Log(dialogueTrigger[index]);
            Choise(dialogueTrigger[index]);
            index++;
        }
    }

    private void Update()
    {
        if(DialogueTagDetector.instance.IsTagExist("mission", "get_flower"))
        {
            StageHandlerGlobal.instance.flowerMissionStage = FlowerMissionStage.COMPLETE;
            int index = 0;

            dialogueTrigger = new DialogueTrigger[flowers.Length];
            foreach(var flower in flowers)
            {
                dialogueTrigger[index] = flower.GetComponent<DialogueTrigger>();
                Choise(dialogueTrigger[index]);
                index++;
            }
        }
    }

    private void Choise(DialogueTrigger dialogueTrigger)
    {
        switch(StageHandlerGlobal.instance.flowerMissionStage)
        {
            case FlowerMissionStage.LOCKED:
                dialogueTrigger.knotName = "go_castle";
                break;
            case FlowerMissionStage.OPEN:
                dialogueTrigger.knotName = "go_castle";
                break;
            case FlowerMissionStage.PROCEED:
                dialogueTrigger.knotName = "mission_proceed";
                break;
            case FlowerMissionStage.COMPLETE:
                dialogueTrigger.knotName = "mission_end";
                break;
            case FlowerMissionStage.FINISH:
                dialogueTrigger.knotName = "mission_end";
                break;
        }
    }
}
