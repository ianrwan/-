using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Ink.Runtime;
using System;

public class DialogueChoiceManager : MonoBehaviour
{
    public static DialogueChoiceManager instance{get; private set;}
    
    [SerializeField] private GameObject choicePanel;
    [SerializeField] private GameObject choicePrefab;


    [Header("Choices")]
    [SerializeField] private GameObject[] choices;
    private Text[] choicesText;
    public bool isChoosing{get; private set;}

    private int optionAmount;

    private void Awake()
    {
        if(instance != null)
            Debug.LogWarning("It's not allowed to set multiple DialogueChoiceManager");
        instance = this;
    }

    public void Start()
    {
        isChoosing = false;
        choicePanel.SetActive(false);

        // init choicesText
        // SetChoicesText();
    }

    private void Update()
    {
        if(!isChoosing)
            return;

        if(InputManager.instance.isSubmit)
        {
            MakeChoice();
        }
    }

    private void SetChoicesText()
    {
        choicesText = new Text[optionAmount];

        int index = 0;
        foreach(var choice in choices)
        {
            choicesText[index++] = choice.GetComponentInChildren<Text>();
        }
    }

    // instantiate the choice gameobjects on the panel
    private void SetChoiceOnPanel(int amount)
    {
        choices = new GameObject[optionAmount];
        for(int i = 0; i < amount; i++)
        {
            choices[i] = Instantiate(choicePrefab, choicePanel.transform);   
            choices[i].GetComponent<PosRelative2D>().x = (uint)i;
        }
    }

    public void DisplayChoices()
    {
        List<Choice> currentChoices = DialogueManager.currentStroy.currentChoices;
        optionAmount = currentChoices.Count;

        // No choice in the dialogue and return
        if(currentChoices.Count == 0)
            return;

        StartCoroutine(SetUp(currentChoices));
        
        DoChoice();
    }

    // let the instantiate have time to copy the gameobjects for setting up the option
    private IEnumerator SetUp(List<Choice> choices)
    {
        SetChoiceOnPanel(optionAmount);
        yield return new WaitForEndOfFrame();

        choicePanel.GetComponent<LengthAndHeightCalculator>().SetUp();
        SetChoicesText();

        int index = 0;
        foreach(Choice choice in choices)
        {
            choicesText[index++].text = choice.text;
        }
    }

    private void DoChoice()
    {
        isChoosing = true;
        choicePanel.SetActive(true);

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        // to clear the first gameobject in EventSystem and delete it
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0]);

        // set the toggle on the first item
        var setToggleCurrent = choicePanel.GetComponent<SetToggleCurrent>();
        setToggleCurrent.SetToggleOnCurrent(EventSystem.current.currentSelectedGameObject);
    }

    public void EndChoice()
    {
        isChoosing = false;
        choicePanel.SetActive(false);
        ClearChoice();
    }

    private void ClearChoice()
    {
        for(int i = 0 ; i < choicePanel.transform.childCount ; i++)
        {
            Destroy(choicePanel.transform.GetChild(i).gameObject);
        }
    }

    public void MakeChoice()
    {
        GameObject choice = EventSystem.current.currentSelectedGameObject;
        DialogueManager.currentStroy.ChooseChoiceIndex((int)choice.GetComponent<PosRelative2D>().x);
        EndChoice();
    }
}
