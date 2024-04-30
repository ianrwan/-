using System.Collections;
using System.Collections.Generic;
using Megumin.Battle;
using UnityEngine;
using UnityEngine.UI;

namespace Megumin.Battle
{
    public class AttackArithmetic : MonoBehaviour
    {
        public static AttackArithmetic instance{get; private set;}

        [Tooltip("Set the battleArithmetic on.")]
        [SerializeField] private BattleArithmetic battleArithmetic;

        private IEntityDataGet currentGet;

        private IEntityDataGet targetGet;
        private IEntityDataSet targetSet;

        private int hurt;

        private void Awake()
        {
            instance = this;
        }

        public void On()
        {
            currentGet = battleArithmetic.handleData.current.GetComponent<IEntityDataGet>();
            targetGet = battleArithmetic.handleData.target.GetComponent<IEntityDataGet>();
            targetSet = battleArithmetic.handleData.target.GetComponent<IEntityDataSet>();

            Calculate();
            DoAnimation();
        }

        private void Calculate()
        {
            hurt = currentGet.GetPower()-TemporaryDefenseCheck();
            var hp = targetGet.GetHealth()-hurt;
            targetSet.SetHealth(hp);
        }

        private void DoAnimation()
        {
            ArithmeticAnimation.instance.SetUp(targetGet.GetGameObject());
            ArithmeticAnimation.instance.Hurt(true);

            // if(targetGet.GetGameObject().tag == "Enemies")
            // {
            //     targetGet.GetGameObject().GetComponentInChildren<Text>().text = hurt+"";
            //     ArithmeticAnimation.instance.ExitText(battleArithmetic.handleData.target.GetComponentInChildren<Text>());
            // }
            targetGet.GetGameObject().GetComponentInChildren<Text>().text = hurt+"";
            ArithmeticAnimation.instance.ExitText(battleArithmetic.handleData.target.GetComponentInChildren<Text>());
        }

        

        // bad code only for temp
        private int TemporaryDefenseCheck()
        {
            if(ArithmeticHandleData.defenseGameObject == null)
                return 0;
            Debug.Log("In middle");

            if(!ReferenceEquals(ArithmeticHandleData.defenseGameObject, battleArithmetic.handleData.target))
                return 0;

            Debug.Log("In defense");
            return targetGet.GetDefense();
        }

    }
}
