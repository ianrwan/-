using System;
using UnityEngine;

namespace Megumin.GameSystem
{
    public class LocalButton : MonoBehaviour, IButton
    {
        public int no;
        public new string name;
        public Action actionClick;

        public void SetUp(int no, string name)
        {
            this.no = no;
            this.name = name;
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
        public int no;
        public string name;
    }
}