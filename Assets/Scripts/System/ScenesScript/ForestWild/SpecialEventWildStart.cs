using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecialEventWildStart : SpecialEventsControl
{
    private DialogueTriggerAutoActive dialogueTrigger;

    protected override void StartEvent()
    {
        if(StageHandlerGlobal.instance.isFirstBattleOver)
        {
            EndSpecialEvent();
            return;
        }       
        StartCoroutine(Wait());  
    }

    private IEnumerator Wait()
    {
        yield return new WaitUntil(() => SetUpHandleManager.instance.isCompleteSetUpOnStart);
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
        SceneManager.LoadScene("Battle");
    }
}
