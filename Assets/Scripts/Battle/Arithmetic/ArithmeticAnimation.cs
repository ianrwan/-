using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Megumin.Battle
{
    // temp
    public class ArithmeticAnimation : MonoBehaviour
    {
        public static ArithmeticAnimation instance{get; private set;}

        [SerializeField] private BattleArithmetic battleArithmetic;
        private Animator animator; 

        private bool isAnimationEnd;

        private void Awake()
        {
            instance = this;
        }

        public void SetUp()
        {
            animator = battleArithmetic.handleData.current.GetComponent<Animator>();

            if(animator == null)
                return;
        }

        private void AnimationEndTrigger()
        {
            isAnimationEnd = true;
        }

        public void Defense(bool check)
        {
            if(animator == null)
                return;     
            animator.SetBool("isDefense", check);
        }
    }

}
