using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueNameManager : MonoBehaviour
{
    public static DialogueNameManager instance{get; private set;}

    [SerializeField] private GameObject namePanel;
    [SerializeField] private Text nameText;

    // temp
    // [SerializeField] private GameObject tempPortraiPanel;
    // [SerializeField] private GameObject hero;
    // [SerializeField] private GameObject warrior;
    // [SerializeField] private GameObject heroHome;
    // temp

    public bool isNameOn;

    private void Awake()
    {
        if(instance != null)
            Debug.LogWarning("It's not allowed to set multiple DialogueNameManager");
        instance = this;
    }

    public void Start()
    {
        if(namePanel == null)
            return;

        isNameOn = false;
        namePanel.SetActive(false);

        // temp
        // hero.SetActive(false);
        // warrior.SetActive(false);
        // heroHome.SetActive(false);
        // tempPortraiPanel.SetActive(false);
        // temp
    }

    private void Update()
    {   
        if(isNameOn == false)
            return;
            
        if(!DialogueManager.instance.isDialoguePlaying)
            TurnOffPanel();
    }

    public void DisplayName()
    {
        if(DialogueTagManager.instance.GetTagValue("namepanel") != null)
            PanelSetting();

        if(DialogueTagManager.instance.GetTagValue("speaker") == null)
            return;

        TurnOnPanel();

        // temp
        // if(DialogueTagManager.instance.GetTagValue("speaker") == "hero")
        // {
        //     tempPortraiPanel.SetActive(true);
        //     warrior.SetActive(false);

        //     if(SceneManager.GetActiveScene().name != "主角家")
        //     {
        //         hero.SetActive(true);
        //     }
        //     else
        //     {
        //         heroHome.SetActive(true);
        //     }
        // }
        // else if(DialogueTagManager.instance.GetTagValue("speaker") == "warrior")
        // {
        //     tempPortraiPanel.SetActive(true);
        //     warrior.SetActive(true);
        //     hero.SetActive(false);
        //     heroHome.SetActive(false);
        // }
        // else
        // {
        //     tempPortraiPanel.SetActive(false);
        //     warrior.SetActive(false);
        //     hero.SetActive(false);
        //     heroHome.SetActive(false);
        // }
        // temp
        Debug.Log(DialogueTagManager.instance.GetTagValue("speaker"));

        try
        {
            nameText.text = DialogueCharacters.dialogueChatactersDictionary[DialogueTagManager.instance.GetTagValue("speaker")];
        }
        catch(NullReferenceException)
        {
            StartCoroutine(UpdateNameText());
        }
    }

    public void PanelSetting()
    {
        switch(DialogueTagManager.instance.GetTagValue("namepanel"))
        {
            case "off":
                TurnOffPanel();
                break;
            case "on":
                TurnOnPanel();
                break;
            default:
                Debug.LogWarning("Panel setting value is incorrect.");
                break;
        }
    }

    private void TurnOnPanel()
    {
        if(namePanel == null)
            Debug.LogError("No Panel Set");
        isNameOn = true;
        namePanel.SetActive(true);
    }

    private void TurnOffPanel()
    {
        isNameOn = false;
        namePanel.SetActive(false);

        // temp
        // warrior.SetActive(false);
        // hero.SetActive(false);
        // heroHome.SetActive(false);
        // tempPortraiPanel.SetActive(false);
        // temp
    }

    private IEnumerator UpdateNameText()
    {
        yield return new WaitUntil(() => SetUpHandleManager.instance.isCompleteSetUpOnStart);
        nameText.text = DialogueCharacters.dialogueChatactersDictionary[DialogueTagManager.instance.GetTagValue("speaker")];
    }
}
