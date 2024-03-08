using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Megumin.GameSystem;

namespace Megumin.Battle
{
    public class BattleArithmetic : MonoBehaviour
    {
        private ArithmeticHandleData arithmeticHandleData;
        public bool isEnd{get; private set;}

        public void SetUp(ArithmeticHandleData arithmeticHandleData)
        {
            this.arithmeticHandleData = arithmeticHandleData;    
        }

        public void On()
        {
            Debug.Log(arithmeticHandleData.combatChoice);
            Debug.Log(arithmeticHandleData.enemy);
            isEnd = true;
        }

        public void Off()
        {
            isEnd = false;
        }
    }
}

