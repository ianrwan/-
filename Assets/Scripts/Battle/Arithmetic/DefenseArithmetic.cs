using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Megumin.Battle
{
    public class DefenseArithmetic : MonoBehaviour
    {
        public static DefenseArithmetic instance{get; private set;}

        [Tooltip("Set the battleArithmetic on.")]
        [SerializeField] private BattleArithmetic battleArithmetic;

        private void Awake()
        {
            instance = this;
        }

        public void On()
        {
            ArithmeticHandleData.defenseGameObject = battleArithmetic.handleData.current;
            ArithmeticAnimation.instance.SetUp(ArithmeticHandleData.defenseGameObject);
            ArithmeticAnimation.instance.Defense(true);
        }

    }
}

