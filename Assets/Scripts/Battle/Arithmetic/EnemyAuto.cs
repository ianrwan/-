using System.Collections;
using System.Collections.Generic;
using Megumin.GameSystem;
using UnityEngine;

// temporary code
namespace Megumin.Battle
{
    public class EnemyAuto : MonoBehaviour
    {
        public static EnemyAuto instance{get; private set;}

        [Tooltip("Set the battleArithmetic on.")]
        [SerializeField] private BattleArithmetic battleArithmetic;

        [Tooltip("Set the battleHandleData on.")]
        [SerializeField] private BattleSystem battleSysmtem;

        private void Awake()
        {
            instance = this;
        }

        public ButtonChoice GetChoice()
        {
            return ButtonChoice.BATTLE_ATTACK;
        }

        public GameObject GetTarget()
        {
            return battleSysmtem.battleHandleData.party.GetPartyGameObjets()[0];
        }
    }
}

