using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SetToggleCurrent : MonoBehaviour
{
    [SerializeField] private GameObject togglePrefab;
    public GameObject toggle{get; private set;}

    private GameObject currentGameObject;

    [Tooltip("can see toggle or not")]
    public bool isToggleVisible = true;

    [Tooltip("can image hover on the choice")]
    public bool isImageHover = false;
    private GameObject currentImage;

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

        BoolCheck();
    }

    private void BoolCheck()
    {
        if(!isToggleVisible)
            toggle.GetComponent<Image>().enabled = false;

        if(isImageHover)
        {
            // first time currentImage doesn't set
            if(currentImage != null)
                currentImage.SetActive(false);

            int sibIndex = toggle.transform.GetSiblingIndex();
            currentImage = toggle.transform.parent.GetChild(sibIndex-1).gameObject;
            currentImage.SetActive(true);
        }
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
