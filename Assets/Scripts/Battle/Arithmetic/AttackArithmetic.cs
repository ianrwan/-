using System.Collections;
using System.Collections.Generic;
using Megumin.Battle;
using UnityEngine;

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
        }

        private void Calculate()
        {
            var hp = targetGet.GetHealth()-currentGet.GetPower()+TemporaryDefenseCheck();
            targetSet.SetHealth(hp);
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
