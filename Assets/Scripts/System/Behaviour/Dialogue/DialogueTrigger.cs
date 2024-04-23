using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool isPlayerCollide{get; private set;}

    [Header("Ink Json")]
    [SerializeField] private TextAsset inkJson;

    private void Awake()
    {
        isPlayerCollide = false;
    }

    private void Update()
    {
        if(!isPlayerCollide)
            return;

        if(InputManager.instance.isInteract && !DialogueManager.instance.isDialoguePlaying)
            StartDialogue();
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.tag == "Player")
            isPlayerCollide = true;
        
    } 

    private void OnCollisionExit2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.tag == "Player")
            isPlayerCollide = false;
    }

    private void StartDialogue()
    {
        DialogueManager.instance.EnterDialogue(inkJson);
        InputManager.instance.SetIsInteractToFalse();
    }
}
