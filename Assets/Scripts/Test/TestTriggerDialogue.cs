using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTriggerDialogue : MonoBehaviour
{
    public DialogueTriggerAutoActive dialogueTriggerAutoActive;

    public void Start()
    {
        StartCoroutine(WaitForSetUp());
    }

    private IEnumerator WaitForSetUp()
    {
        yield return new WaitUntil(() => SetUpHandleManager.instance.isCompleteSetUpOnStart);
        dialogueTriggerAutoActive.Trigger();
    }
}
