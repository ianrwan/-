using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetToggleCurrent : MonoBehaviour
{
    [SerializeField] private GameObject togglePrefab;
    public GameObject toggle{get; private set;}

    private GameObject currentGameObject;

    private void Update()
    {
        // check if there is no gameobjects for selection 
        if(currentGameObject == null)
            return;

        // check if the currentSelectedGameObject is changed
        if(ReferenceEquals(currentGameObject, EventSystem.current.currentSelectedGameObject))
            return;

        // if the currentSelected GameObject is changed and toggle should also change to new gameobject
        SetToggleToNewObject(EventSystem.current.currentSelectedGameObject);
    }

    public void SetToggleOnCurrent(GameObject currentGameObject)
    {
        if(toggle != null)
            Debug.LogError("toggle is still existed, you should better destroy the toggle first");

        this.currentGameObject = currentGameObject;
        toggle = Instantiate(togglePrefab, currentGameObject.transform);
    }

    public void SetToggleToNewObject(GameObject currentGameObject)
    {
        DeleteToggle();
        SetToggleOnCurrent(currentGameObject);
    }

    public void DeleteToggle()
    {
        if(toggle == null)
            return;

        Destroy(toggle);
        toggle = null;
    }
}
