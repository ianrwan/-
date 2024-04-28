using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Megumin.Scene.Preface
{
    public class SpecialEventPrefaceStart : SpecialEventsControl
    {
        private DialogueTriggerAutoActive dialogueTrigger;

        protected override void StartEvent()
        {
            dialogueTrigger = GetComponent<DialogueTriggerAutoActive>();
            dialogueTrigger.Trigger();  
        }

        protected override void DetectEvent()
        {
            if(DialogueManager.instance.isEnd)
                EndSpecialEvent();
        }

        protected override void EndEvent()
        {
            SceneManager.LoadScene("主角家");
        }

        
    }
}

