using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

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
            dialogueText.text = (story.Trim() == "NULL") ? "" : story.Trim();
            
            DialogueTagManager.instance.SetTags();
            DialogueChoiceManager.instance.DisplayChoices();
            DialogueNameManager.instance.DisplayName();
        }
        else
        {
            ExitDialogue();
        }

        InputManager.instance.SetAllZInputToFalse();
    }



}
