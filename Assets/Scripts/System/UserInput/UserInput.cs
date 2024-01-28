using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Megumin.GameSystem
{
    public class UserInput : MonoBehaviour
    {
        public int HandleUpdate()
        {
            if(Input.GetKey(KeyCode.Keypad0))
            {
                return 0;
            }
            if(Input.GetKey(KeyCode.Keypad1))
            {
                return 1;
            }
            return -1;
        }
    }

}