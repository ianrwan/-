using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance{get; private set;}
    public Vector2 movement{get; private set;}
    public bool isInteract{get; private set;}
    public bool isSubmit{get; private set;}

    private void Awake()
    {
        instance = this;
        isInteract = false;
        isSubmit = false;
    }
    
    // move contains WASD and Arrows
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    // interact will happen when Z pressed
    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.started)
            isInteract = true;
        else if(context.canceled)
            isInteract = false;
    }

    // submit will happen when Z pressed
    public void OnSubmit(InputAction.CallbackContext context)
    {
        if(context.started)
            isSubmit = true;
        else if(context.canceled)
            isSubmit = false;      
    }

    // means the interaction is done
    public void SetIsInteractToFalse()
    {
        isInteract = false;
    }

    // means the submit is done
    public void SetIsSubmitToFalse()
    {
        isSubmit = false;
    }

    // means the input value Z should be refresh
    public void SetAllZInputToFalse()
    {
        isInteract = false;
        isSubmit = false;
    }
}

