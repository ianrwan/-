using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecialEventForestWildEnd : SpecialEventsControl
{
    private DialogueTriggerAutoActive dialogueTrigger;

    protected override void StartEvent()
    {
        StartCoroutine(Wait());  
    }

    private IEnumerator Wait()
    {
        Debug.Log("in one");
        yield return new WaitUntil(() => SetUpHandleManager.instance.isCompleteSetUpOnStart);
        Debug.Log("in two");
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
        SceneManager.LoadScene("Continue");
    }
}
