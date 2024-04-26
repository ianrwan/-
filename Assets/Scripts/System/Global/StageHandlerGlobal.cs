using System.Collections;
using System.Collections.Generic;
using Megumin.GameSystem;
using UnityEngine;

public class StageHandlerGlobal : MonoBehaviour
{
    public static StageHandlerGlobal instance{get; private set;}
    
    [Tooltip("Handle what the stage is in current.")]
    public Stage stage;

    public void Awake()
    {
        if(instance != null)
            return;
        instance = this;
    }
}
