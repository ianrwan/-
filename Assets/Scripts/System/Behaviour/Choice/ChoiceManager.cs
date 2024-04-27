using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    public static ChoiceManager instance{get; private set;}

    [Tooltip("Input the gameobjects which is attached choiceSelectors into the manager.")]
    [SerializeField] private ChoiceSelector[] choiceSelectors;

    [Tooltip("Choose what the panel to trun on when game starts.")]
    [SerializeField] private string startPanelName;

    private void Awake()
    {
        if(instance != null)
            Debug.LogWarning("It's not allowed to set multiple DialogueChoiceManager");
        instance = this;
    }

    private void Start()
    {
        if(startPanelName == "")
            return;
        TurnOn(startPanelName);
    }

    public void TurnOn(string name)
    {
        var selector = Array.Find(choiceSelectors, selector => selector.Name == name);
        if(selector == null)
        {
            Debug.LogWarning("No selector calls "+name+".");
            return;
        }

        selector.StartChoice();
    }
}
