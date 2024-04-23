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

    private void Awake()
    {
        if(instance != null)
            Debug.LogWarning("It's not allowed to set multiple DialogueManager");       
        instance = this;
    }

    public void Start()
    {
        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if(!isDialoguePlaying)
            return;

        if(DialogueChoiceManager.instance.isChoosing)
            return;

        if(InputManager.instance.isSubmit)
            ContinueStory();
    }

    public void EnterDialogue(TextAsset inkJson)
    {
        isDialoguePlaying = true;
        dialoguePanel.SetActive(true);

        currentStroy = new Story(inkJson.text);
        ContinueStory();
    }

    public void ExitDialogue()
    {
        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if(currentStroy.canContinue)
        {
            dialogueText.text = currentStroy.Continue();
            DialogueChoiceManager.instance.DisplayChoices();
        }
        else
        {
            ExitDialogue();
        }

        InputManager.instance.SetAllZInputToFalse();
    }



}
