using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Megumin.GameSystem;
using Unity.PlasticSCM.Editor.WebApi;
using JetBrains.Annotations;

namespace Megumin.Battle
{
    public class BattleArithmetic : MonoBehaviour
    {
        public ArithmeticHandleData handleData{get; private set;}
        public bool isEnd{get; private set;}

        public void SetUp(ArithmeticHandleData handleData)
        {
            this.handleData = handleData;    
        }

        public void On()
        {
            EnemyCheck();
            PlayerDefenseCheck();
            ArithmeticAnimation.instance.SetUp();

            StatusChoice();

            // Debug.Log("in Arithmeic"+check++);
            Debug.Log("Action: "+handleData.combatChoice);
            Debug.Log("Current: "+handleData.current);
            Debug.Log("Target: "+handleData.target);
            
            isEnd = true;
        }

        private void EnemyCheck()
        {
            if(handleData.current.tag == "Enemies")
            {
                handleData.combatChoice = EnemyAuto.instance.GetChoice();
                handleData.target = EnemyAuto.instance.GetTarget();
            }
        }

        private void PlayerDefenseCheck()
        {
            if(handleData.current.tag == "Characters")
            {
                ArithmeticHandleData.defenseGameObject = null;
                ArithmeticAnimation.instance.SetUp();
                ArithmeticAnimation.instance.Defense(false);
            }
        }

        private void StatusChoice()
        {
            switch(handleData.combatChoice)
            {
                case ButtonChoice.BATTLE_ATTACK:
                    AttackArithmetic.instance.On();
                    break;
                case ButtonChoice.BATTLE_DEFENCE:
                    DefenseArithmetic.instance.On();
                    break;
            }
        }

        public void Off()
        {
            isEnd = false;
        }
    }
}

