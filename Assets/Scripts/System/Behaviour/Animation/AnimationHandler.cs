using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public Action OnFinshed;

    public void AnimationFinishTrigger()
    {
        OnFinshed?.Invoke();
    }
}
