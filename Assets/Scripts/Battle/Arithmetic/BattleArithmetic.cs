using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Megumin.GameSystem;

namespace Megumin.Battle
{
    public class BattleArithmetic : MonoBehaviour
    {
        private static int check = 1;
        private ArithmeticHandleData arithmeticHandleData;
        public bool isEnd{get; private set;}

        public void SetUp(ArithmeticHandleData arithmeticHandleData)
        {
            this.arithmeticHandleData = arithmeticHandleData;    
        }

        public void On()
        {
            // Debug.Log("in Arithmeic"+check++);
            Debug.Log(arithmeticHandleData.combatChoice);
            Debug.Log(arithmeticHandleData.current);
            Debug.Log(arithmeticHandleData.target);
            isEnd = true;
        }

        public void Off()
        {
            isEnd = false;
        }
    }
}

