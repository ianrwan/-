using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Megumin.Scene.Title
{
    public class TitleEvent : MonoBehaviour
    {

        [SerializeField] private GameObject textPressZ;
        [SerializeField] private GameObject choicePanel;
        [SerializeField] private ChoiceSelector choiceSelector;

        private bool isSet = false;

        private void Update()
        {
            if(InputManager.instance.isInteract && !isSet)
                TurnOnPanel();
        }

        private void TurnOnPanel()
        {
            isSet = true;
            textPressZ.SetActive(false);
            choicePanel.SetActive(true);
            choiceSelector.StartChoice();
        }
    }

}

