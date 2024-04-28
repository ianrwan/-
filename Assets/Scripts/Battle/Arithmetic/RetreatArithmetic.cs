using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Megumin.Battle
{
    public class RetreatArithmetic : MonoBehaviour
    {
        public static RetreatArithmetic instance{get; private set;}

        [Tooltip("Set the battleArithmetic on.")]
        [SerializeField] private BattleArithmetic battleArithmetic;
        public bool isRetreat{get; private set;}

        private void Awake()
        {
            instance = this;
        }

        public void On()
        {
            isRetreat = true;
            ArithmeticAnimation.instance.SetUp(battleArithmetic.handleData.current);
            ArithmeticAnimation.instance.Retreat(true);
        }

    }
}

