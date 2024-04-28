using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Megumin.GameSystem;
using UnityEngine.UI;

namespace Megumin.Battle
{
    public class BattleArithmetic : MonoBehaviour
    {
        public ArithmeticHandleData handleData{get; private set;}
        public bool isEnd{get; private set;}

        private bool isFinished;

        public void SetUp(ArithmeticHandleData handleData)
        {
            this.handleData = handleData;    
        }

        private void Update()
        {
            if(isEnd)
                return;

            if(!ArithmeticAnimation.instance.isAnimationEnd)
                return;

            if(DeadArithmetic.instance.isDead)
                return;

            if(RetreatArithmetic.instance.isRetreat)
                return;

            StartCoroutine(WaitForEnd());
        }

        private IEnumerator WaitForEnd()
        {
            isEnd = true;
            isFinished = false;
            yield return new WaitForSeconds(0.5f);
        }

        public void On()
        {
            isEnd = false;
            EnemyCheck();
            PlayerDefenseCheck();

            StatusChoice();
            DeadArithmetic.instance.On();

            // Debug.Log("in Arithmeic"+check++);
            Debug.Log("Action: "+handleData.combatChoice);
            Debug.Log("Current: "+handleData.current);
            Debug.Log("Target: "+handleData.target);
            
            isFinished = true;
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
                Debug.Log("in");
                ArithmeticHandleData.defenseGameObject = null;
                ArithmeticAnimation.instance.SetUp(handleData.current);
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
                case ButtonChoice.BATTLE_RETREAT:
                    RetreatArithmetic.instance.On();
                    break;
            }
        }

        public void Off()
        {
            isEnd = false;
        }
    }
}

