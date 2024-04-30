using System.Collections;
using System.Collections.Generic;
using Megumin.GameSystem;
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
            StartCoroutine(Wait());
        }

        private IEnumerator Wait()
        {
            yield return new WaitForSeconds(2);
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

            if(DialogueTagDetector.instance.IsTagExist("sound", "knock"))
            {
                if(DialogueTagDetector.instance.Length > 1)
                    TemporaryOff();
                StartCoroutine(DoSounds());
            }

            if(DialogueTagDetector.instance.IsTagExist("sound", "shock"))
            {
                DialogueManager.instance.isLockedContinue = true;
                StartCoroutine(DoSounds());
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

        // Do all the sounds.
        private IEnumerator DoSounds()
        {
            string sound = "";

            int index = 0;
            while((sound = DialogueTagDetector.instance.GetValue(index)) != null)
            {
                AudioManager.instance.Play(sound);
                var audio = AudioManager.instance.GetAudios(sound);

                yield return new WaitForSeconds(audio.audioSource.clip.length);
                index++;
            }

            DialogueManager.instance.isLockedContinue = false;

            if(DialogueTagDetector.instance.Length > 1)
            {
                TemporaryOn();
            }
        }

        // This is a bad code, it will be replaced after making a good tag system
        private void TemporaryOff()
        {
            Debug.Log("Off");
            DialogueManager.instance.StopDialogue();
        }

        private void TemporaryOn()
        {
            DialogueManager.instance.ContinueDialogue();
        }
    }

}
