using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool isPlayerCollide{get; private set;}

    [Header("Ink Json")]
    [SerializeField] protected TextAsset inkJson;

    [Tooltip("To input the knot name.")]
    public string knotName;

    private void Awake()
    {
        isPlayerCollide = false;
    }

    protected virtual void Update()
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

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.tag == "Player")
            isPlayerCollide = true;
    } 

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.tag == "Player")
            isPlayerCollide = false;
    }

    protected void StartDialogue()
    {
        if(knotName != null && knotName != "")
            DialogueManager.instance.EnterDialogue(inkJson, knotName);
        else
            DialogueManager.instance.EnterDialogue(inkJson);
        InputManager.instance.SetIsInteractToFalse();
    }
}
