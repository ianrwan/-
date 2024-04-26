using System.Collections;
using System.Collections.Generic;
using Megumin.GameSystem;
using UnityEngine;

// This manager should use SetUpHandleManger to SetUp.
public class TransportManager : MonoBehaviour, ISetUp
{
    public static TransportManager instance{get; private set;}
    public TagStringDictionary<TransportTag> find{get; private set;}

    private void Awake()
    {
        if(instance != null)
            Debug.LogWarning("It's not allowed to set multiple ChoiceManager");
        instance = this;
    }

    public void SetUp()
    {
        find = new TagStringDictionary<TransportTag>("transport_scene");
        find.SetUp();
    }


    
}
