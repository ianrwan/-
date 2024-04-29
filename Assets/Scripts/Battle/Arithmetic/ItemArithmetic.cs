using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Megumin.Battle
{
    public class ItemArithmetic : MonoBehaviour
    {
        public static ItemArithmetic instance{get; private set;}

        [Tooltip("Set the battleArithmetic on.")]
        [SerializeField] private BattleArithmetic battleArithmetic;
        public bool isRetreat{get; private set;}

        private void Awake()
        {
            instance = this;
        }

        public void On()
        {
            SceneGlobal.transportTag = GameSystem.TransportTag.NULL;
            SceneManager.LoadScene("End");
        }

    }
}

