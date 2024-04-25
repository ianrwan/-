using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueNameManager : MonoBehaviour
{
    public static DialogueNameManager instance{get; private set;}

    [SerializeField] private GameObject namePanel;
    [SerializeField] private Text nameText;

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
        if(DialogueTagManager.instance.GetTagValue("speaker") == null)
            return;

        TurnOnPanel();
        nameText.text = DialogueCharacters.dialogueChatactersDictionary[DialogueTagManager.instance.GetTagValue("speaker")];
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
    }
}
