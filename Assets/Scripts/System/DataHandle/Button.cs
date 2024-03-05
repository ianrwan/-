using System;
using UnityEngine;
using UnityEngine.UI;

namespace Megumin.GameSystem
{
    public class LocalButton : MonoBehaviour, IButton
    {
        public ButtonChoice status;
        public new string name;
        public Action actionClick;

        public void SetUp(SerealizableButton button)
        {
            status = button.status;
            name = button.name;
        }

        public void Click()
        {
            actionClick?.Invoke();
        }

        public void Cover()
        {
            
        }
    }

    public class SerealizableButton
    {
        public ButtonChoice status;
        public string name;
    }
}