using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Megumin.Scene.HeroHouse
{
    public class SpecialEventStart : SpecialEventsControl
    {
        [Header("Custom")]
        [SerializeField] private GameObject blackImage;

        private Animator animator;
        private AnimationHandler animationHandler;
        private DialogueTriggerAutoActive dialogueTrigger;

        protected override void StartEvent()
        {
            blackImage.SetActive(true);
            Vector2 playerVector2 = GameObject.FindGameObjectWithTag("Player").transform.position;
            Camera.main.transform.position = new Vector3(playerVector2.x, playerVector2.y, Camera.main.transform.position.z);

            dialogueTrigger = GetComponent<DialogueTriggerAutoActive>();
            dialogueTrigger.Trigger();
        }

        protected override void DetectEvent()
        {
            if(DialogueTagDetector.instance.IsTagExist("anime" ,"black_disappear"))
            {
                DialogueManager.instance.StopDialogue();
                animator = blackImage.GetComponent<Animator>();
                animationHandler = blackImage.GetComponent<AnimationHandler>();
                animationHandler.OnFinshed = DialogueManager.instance.ContinueDialogue;
                DoAnime();
            }

            if(DialogueManager.instance.isEnd)
                EndSpecialEvent();
        }

        protected override void EndEvent()
        {
            blackImage.SetActive(false);
        }

        private void DoAnime()
        {
            animator.SetBool("IsStart", true);
        }
    }

}
