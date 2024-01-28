using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationStatus{IDLE = 0, NORMAL_ATTACK = 1, SKILL = 2}
public class Character : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public Action animeCharacter;
    public Vector3 position;

    private void Start()
    {

    }

    public void SetAnime(AnimationStatus animeStaus)
    {
        switch(animeStaus)
        {
            case AnimationStatus.IDLE:
                animeCharacter = IdleAnime;
                break;
            
            case AnimationStatus.NORMAL_ATTACK:
                animeCharacter = AttakAnime;
                break;

            case AnimationStatus.SKILL:
                animeCharacter = SkillAnime;
                break;
            
        }
    }

    private void IdleAnime()
    {
        animator.SetInteger("Status", (int)AnimationStatus.IDLE);
    }

    private void AttakAnime()
    {
        animator.SetInteger("Status", (int)AnimationStatus.NORMAL_ATTACK);
    }

    private void SkillAnime()
    {
        animator.SetInteger("Status", (int)AnimationStatus.SKILL);
    }
}
