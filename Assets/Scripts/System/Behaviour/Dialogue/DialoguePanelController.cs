using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

namespace Megumin.GameSystem.Behaviour
{
    public abstract class DialoguePanelController : MonoBehaviour
    {
        [SerializeField] private GameObject panel;

        private string panelTag;

        // 對不一樣的 panel 進行不一樣的變更
        public abstract void SetData();
        
        // 設定外部的 delegate 設定為 displayPanel, 通常使用的 delegate method 來自 DialogueManager
        protected abstract void SetController();

        private void Awake()
        {
            SetController();
            panel.SetActive(false);
            DialogueManager.panelTurnOff += TurnOffPanel;
        }

        // 有 tag 要使用 panel 
        public void DisplayPanel(string panelTagName)
        {
            panelTag = DialogueTagManager.instance.GetTagValue(panelTagName);
            SetData();
            if(panelTag == null)
                return;
            PanelSetting();
        }

        private void PanelSetting()
        {
            switch(panelTag)
            {
                case "on":
                    TurnOnPanel();
                    Debug.Log("PanelOn");
                    break;
                case "off":
                    TurnOffPanel();
                    break;
                default:
                    Debug.LogWarning($"Invalid tag in panelTag. panelTag: {panelTag}");
                    break;
            }
        }

        private void TurnOnPanel()
        {
            panel.SetActive(true);
        }

        private void TurnOffPanel()
        {
            panel.SetActive(false);
        }
    }
}

