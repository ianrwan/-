using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Megumin.GameSystem;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Megumin.Battle
{
    public class RetreatArithmetic : MonoBehaviour
    {
        public static RetreatArithmetic instance{get; private set;}

        [Tooltip("Set the battleArithmetic on.")]
        [SerializeField] private BattleArithmetic battleArithmetic;
        public bool isRetreat{get; private set;}

        [Header("Custom")]
        [SerializeField] public DialogueTriggerAutoActive dialogueTrigger;
        [SerializeField] public GameObject dialogueSystem;

        private bool isAnimeComplete;

        private void Awake()
        {
            instance = this;
        }

        public void On()
        {
            isRetreat = true;

            ArithmeticAnimation.instance.SetUp(battleArithmetic.handleData.current);
            ArithmeticAnimation.instance.Retreat(true);

            if(StageHandlerGlobal.instance.isFirstShockOver)
            {
                StartCoroutine(WaitAnime());
                return;
            }

            if(StageHandlerGlobal.instance.isFirstShockOver == false)
                StartCoroutine(Wait());
        }

        private IEnumerator Wait()
        {
            yield return new WaitForSeconds(2);

            dialogueSystem.SetActive(true);
            dialogueTrigger.knotName = "first_battle_shock";
            dialogueTrigger.TriggerMutipleTime();
            isAnimeComplete = true;            
        }

        private IEnumerator WaitAnime()
        {
            yield return new WaitForSeconds(2);
            GoScene();
        }

        private void Update()
        {
            if(isAnimeComplete == true && DialogueManager.instance.isEnd)
                GoScene();
        }

        private void GoScene()
        {
            SpecialEventsControl.Reset();
            StageHandlerGlobal.instance.isFirstShockOver = true;
            SceneGlobal.transportTag = TransportTag.HERO_VILLAGE_WORLD;
            SceneManager.LoadScene("新手村");
        }

    }
}

