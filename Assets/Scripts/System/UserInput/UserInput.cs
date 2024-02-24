using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Megumin.GameSystem
{
    public class UserInput : MonoBehaviour
    {
        public KeyBoard HandleUpdate()
        {
            if(Input.GetKeyDown(KeyCode.RightArrow))
                return KeyBoard.RIGHT;

            if(Input.GetKeyDown(KeyCode.LeftArrow))
                return KeyBoard.LEFT;

            if(Input.GetKeyDown(KeyCode.UpArrow))
                return KeyBoard.UP;

            if(Input.GetKeyDown(KeyCode.DownArrow))
                return KeyBoard.DOWN;

            if(Input.GetKeyDown(KeyCode.Z))
                return KeyBoard.Z;

            if(Input.GetKeyDown(KeyCode.X))
                return KeyBoard.X;
            
            if(Input.GetKeyDown(KeyCode.Escape))
                return KeyBoard.ESC;

            return KeyBoard.NULL;
        }
    }

}