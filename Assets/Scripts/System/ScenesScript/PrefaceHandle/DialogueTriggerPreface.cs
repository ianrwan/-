using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTriggerPreface : DialogueTrigger
{
    private bool isDialogueStart = false;
    protected override void Update()
    {
        if(!isDialogueStart && !DialogueManager.instance.isDialoguePlaying)
        {
            isDialogueStart = true;
            StartDialogue();
        }
    }
}
