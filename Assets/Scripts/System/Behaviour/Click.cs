using System;
using UnityEngine;

// Click => set the function you wanna do for action
namespace Megumin.GameSystem
{
    public class Click : MonoBehaviour
    {
        public System.Action actionClick;

        public void Do()
        {
            actionClick?.Invoke();
            Reset();
        }

        public void Reset()
        {
            actionClick = null;
        }
    }
}

