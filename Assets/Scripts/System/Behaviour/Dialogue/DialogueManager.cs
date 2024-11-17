using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using System;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance{get; private set;}
    public static Story currentStroy{get; private set;}

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Text dialogueText;

    public bool isDialoguePlaying{get; private set;}
    public bool isEnd{get; private set;}

    // When you wanna wait for the dialogue go ahead directly and you can turn on the lock
    [HideInInspector]
    public bool isLockedContinue;

    // 將 controller 中有需要被 ContinueStory 呼叫的 method 放入 delegate
    // input: 所要找的標籤名稱
    public delegate void DisplayController(string tagName);
    public static DisplayController portraitPanelController;

    // 將需要在對話關閉時，其他需要一同關閉的 panel
    // 會在 ExitDialogue 執行
    public static Action panelTurnOff;

    private void Awake()
    {
        if(instance != null)
            Debug.LogWarning("It's not allowed to set multiple DialogueManager");    
        instance = this;

        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if(!isDialoguePlaying)
            return;

        if(DialogueChoiceManager.instance.isChoosing)
            return;

        if(isLockedContinue)
            return;

        if(InputManager.instance.isSubmit)
            ContinueStory();
    }

    private void OnDestroy()
    {
        panelTurnOff = null;
    }

    public void EnterDialogue(TextAsset inkJson)
    {
        isDialoguePlaying = true;
        isEnd = false;
        dialoguePanel.SetActive(true);

        currentStroy = new Story(inkJson.text);
        ContinueStory();
    }

    public void EnterDialogue(TextAsset inkJson, string knot)
    {
        isDialoguePlaying = true;
        isEnd = false;
        dialoguePanel.SetActive(true);

        currentStroy = new Story(inkJson.text);
        currentStroy.ChoosePathString(knot);
        ContinueStory();
    }

    public void ExitDialogue()
    {
        isDialoguePlaying = false;
        isEnd = true;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        panelTurnOff.Invoke();
    }

    public void StopDialogue()
    {
        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);
    }

    public void ContinueDialogue()
    {
        isDialoguePlaying = true;
        dialoguePanel.SetActive(true);
        ContinueStory();
    }

    private void ContinueStory()
    {
        string story = "";
        if(currentStroy.canContinue)
        {
            story = currentStroy.Continue();
            if(story.Trim() == "")
            {
                ContinueStory();
                return;
            }

            dialogueText.text = (story.Trim() == "NULL") ? "" : story.Trim();
            
            DialogueTagManager.instance.SetTags();
            DialogueChoiceManager.instance.DisplayChoices();
            DialogueNameManager.instance.DisplayName();
            portraitPanelController.Invoke("portrait-panel");
        }
        else
        {
            ExitDialogue();
        }

        InputManager.instance.SetAllZInputToFalse();
    }



}
