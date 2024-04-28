using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Megumin.Scene.BattleDialogue
{
    public class SpecialEventBattleDialogueStart : SpecialEventsControl
    {
        private DialogueTriggerAutoActive dialogueTrigger;

        protected override void StartEvent()
        {
            dialogueTrigger = GetComponent<DialogueTriggerAutoActive>();
            StartCoroutine(Wait());  
        }

        // Data still waiting input, so this for wait for the input complete
        private IEnumerator Wait()
        {
            yield return new WaitUntil(() => SetUpHandleManager.instance.isCompleteSetUpOnStart);
            dialogueTrigger.Trigger();
        }

        protected override void DetectEvent()
        {
            if(DialogueManager.instance.isEnd)
                EndSpecialEvent();
        }

        protected override void EndEvent()
        {
            SceneLoad.instance.DeleteScene("BattleDialogue");
        }
    }
}

