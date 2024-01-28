using System;
using UnityEngine;

namespace Megumin.GameSystem
{
    public class LocalButton : MonoBehaviour, IButton
    {
        public int no;
        public Action actionClick;
        public void Click()
        {
            actionClick?.Invoke();
        }
    }
}
