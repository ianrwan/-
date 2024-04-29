using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Megumin.Scene.BattleDialogue
{
    public class SpecialEventBattleDialogueStart : SpecialEventsControl
    {
        private DialogueTriggerAutoActive dialogueTrigger;
        public GameObject dialogueGameObject;

        protected override void StartEvent()
        {
            if(StageHandlerGlobal.instance.isFirstBattleOver == true)
            {
                EndSpecialEvent();
                return;
            }
                
            dialogueTrigger = GetComponent<DialogueTriggerAutoActive>();
            StartCoroutine(Wait());  
        }

        // Data still waiting input, so this for wait for the input complete
        private IEnumerator Wait()
        {
            yield return new WaitUntil(() => SetUpHandleManager.instance.isCompleteSetUpOnStart);
            dialogueTrigger.TriggerMutipleTime();
        }

        protected override void DetectEvent()
        {
            if(DialogueManager.instance.isEnd)
                EndSpecialEvent();
        }

        protected override void EndEvent()
        {
            StageHandlerGlobal.instance.isFirstBattleOver = true;
            dialogueGameObject.SetActive(false);
        }
    }
}

