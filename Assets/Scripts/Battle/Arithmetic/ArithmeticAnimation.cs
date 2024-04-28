using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Megumin.Battle
{
    // temp
    public class ArithmeticAnimation : MonoBehaviour
    {
        public static ArithmeticAnimation instance{get; private set;}

        [SerializeField] private BattleArithmetic battleArithmetic;
        private GameObject animationGameObject;
        private Animator animator; 

        // private Text updatingText;

        public bool isAnimationEnd{get; private set;}

        private void Awake()
        {
            instance = this;
            isAnimationEnd = true;
        }

        public void SetUp(GameObject gameObject)
        {
            animationGameObject = gameObject;
            animator = gameObject.GetComponent<Animator>();

            if(animator == null)
                return;
        }

        private void AnimationEndTrigger()
        {
            Debug.Log("in ainmaiton end trigger");
            isAnimationEnd = true;

            Hurt(false);
            Hit(false);
        }

        private void ExitPoint()
        {
            animationGameObject.GetComponent<AnimationHandler>().OnFinshed = AnimationEndTrigger;
            // animationGameObject.GetComponent<AnimationHandler>().OnFinshed += battleArithmetic.WaitEnd;
        }

        public void ExitText(Text text)
        {
            StartCoroutine(WaitExitText(text));
        }

        private IEnumerator WaitExitText(Text textComponent)
        {
            yield return new WaitForSeconds(0.5f);
            textComponent.text = "";
        }

        public void Defense(bool check)
        {
            if(animator == null)
                return;     
            
            animator.SetBool("isDefense", check);
        }

        public void Dead(bool check)
        {
            if(animator == null)
                return;

            isAnimationEnd = true;
            animator.SetBool("isDie", check);
        }

        public void Hurt(bool check)
        {
            if(animator == null)
                return;

            if(check == true)
            {
                isAnimationEnd = false;
                ExitPoint();
            }

            Debug.Log(animationGameObject);

            animator.SetBool("isHurt", check);
        }

        public void Hit(bool check)
        {
            if(animator == null)
                return;

            if(check == true)
            {
                isAnimationEnd = false;
                ExitPoint();
            }
                
            animator.SetBool("isStartAttack", check);
        }

        public void Retreat(bool check)
        {
            if(animator == null)
                return;

            if(check == true)
            {
                isAnimationEnd = false;
                ExitPoint();
            }
                
            animator.SetBool("isRetreat", check);
        }
    }

}
