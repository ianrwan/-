using System.Collections;
using System.Collections.Generic;
using Megumin.GameSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransportTrigger : MonoBehaviour
{
    [Tooltip("Set the transport place where the player go to.")]
    public TransportTag transportTag;

    [Tooltip("Check if trigger will happen or not.")]
    public bool isLock = false;

    [Tooltip("Unlock until stage turn pass.")]
    public Stage until;

    [Tooltip("Check if go to the scene PassingBlack first.")]
    public bool isGoPassingBlack = false;

    [Tooltip("Check if go to the scene Passing first.")]
    public bool isGoPassing = false;
    
    public void Start()
    {
        if(isGoPassingBlack && isGoPassing)
            Debug.LogWarning("isGoPassingBlack and isGoPassing shouldn't be both true.");
    }

    public void Update()
    {
        if(until == Stage.FIRST_START)
            return;
            
        if(isLock == true)
        {
            if(StageHandlerGlobal.instance.stage == until)
                isLock = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(isLock == true)
            return;

        if(collider2D.gameObject.tag != "Player")
            return;

        SceneGlobal.transportTag = transportTag;
        SceneGlobal.goScene = TransportManager.instance.find.dictionary[transportTag];

        if(isGoPassingBlack)
        {
            SceneManager.LoadScene("PassingBlack");
            return;
        }
            

        if(isGoPassing)
        {
            SceneManager.LoadScene("Passing");
            return;
        }
        Debug.Log("How");   
        // SceneManager.LoadScene(TransportManager.instance.find.dictionary[transportTag]);
    }
}
