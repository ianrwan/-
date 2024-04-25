using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// dialogue will trigger when accessing some situation without pressing
public class DialogueTriggerAutoActive : DialogueTrigger
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
