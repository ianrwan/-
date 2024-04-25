using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Megumin.Scene.HeroHouse
{
    public class SpecialEventStart : SpecialEventsControl
    {
        [SerializeField] private GameObject blackImage;

        private Animator animator;
        private AnimationHandler animationHandler;

        protected override void StartEvent()
        {

        }

        protected override void DetectEvent()
        {
            if(AnimationManager.instance.IsAnimationExist("black_disappear"))
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

        private void DoAnime()
        {
            animator.SetBool("IsStart", true);
        }
    }

}
