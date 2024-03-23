using System;
using UnityEngine;
using Megumin.MeguminException;
using System.Collections.Generic;

// Click => set the function you wanna do for action
namespace Megumin.GameSystem
{
    public class Click : MonoBehaviour
    {
        public Action actionClick;
        private bool isKeep = false;

        /* 
            Do will invoke actionClick
            Do can only uses one time, and actionClick will be reset
            [Warning] It's not allowed to use Do after using DoKeep until it resets by Reset
         */
        public void Do()
        {
            if(isKeep == true)
                throw new NotResetException("It's not allowed to use Do after using DoKeep until it resets by Reset");
            actionClick();
            // Reset();
        }

        // DoKeep won't reset actionClick after click
        public void DoKeep()
        {
            isKeep = true;
            actionClick?.Invoke();
        }

        public void Reset()
        {
            Debug.Log("check");
            isKeep = false;
            actionClick = null;
        }
    }
}

