using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    protected GameObject button = null;
    protected GameObject selector = null;
    private int childTotalNum;
    protected int buttonIndex;

    public Action OptionOn;
    public Action OptionOff;
    public static OptionManager instance{get; private set;}

    private bool isChoosing;
    private List<Color32> previousColor;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        FindSelector("Grid");
        childTotalNum = button.transform.childCount;
        IsButtonOn();
    }

    public void Reset()
    {
        IsButtonOff();
        button = button.transform.parent.GetChild(0).gameObject;
        selector.transform.SetParent(button.transform);

        button = null;
        selector = null;
        childTotalNum = 0;
        buttonIndex = 0;
    }

    protected virtual void FindSelector(string selectorAcestorName)
    {
        var objectFound = GameObject.FindGameObjectsWithTag("Selector"); // this is an array

        int i = 0;
        while(button == null)
        {
            string ancestorName = objectFound[i].transform.parent.parent.name; // three depths => Grid/Button*Attack*/Selector
            // Debug.Log(ancestorName);
            if(ancestorName == selectorAcestorName)
            {
                button = objectFound[i].transform.parent.gameObject; // set value to global button
                selector = objectFound[i].gameObject;
                buttonIndex = button.transform.GetSiblingIndex();
                Debug.Log("Selector is found in path "+ button.transform.parent.name +"/"+ button.name);
            }

            i++;
        }
    }

    private void Update()
    {
    }

    private GameObject FindChildbyName(string name)
    {
        bool isFound = false;
        int i = 0;

        while(!isFound && i < childTotalNum)
        {
            // Debug.Log("In FindChildbyName "+name);
            var child = button.transform.GetChild(i);
            if(child.name == name)
            {
                // Debug.Log("Name "+ child.name + " is found");
                return child.gameObject;
            }

            i++;
        }

        Debug.LogWarning("Name: "+name+" can't be found in children");
        return null;
    }

    /** 
    command: int, 
    command = 0, it means up arrow key
    command = 1, it means down arrow key
     **/
    public virtual IEnumerator MoveSelector(int command = 0)
    {
        if(isChoosing == true)
            yield break;

        isChoosing = true;

        if(command == 0)
            buttonIndex = (buttonIndex-1 < 0) ? button.transform.parent.childCount-1 : buttonIndex-1; 
        else
            buttonIndex = (buttonIndex+1 >= button.transform.parent.childCount) ? 0 : buttonIndex+1; 
        var currentButton = button.transform.parent.GetChild(buttonIndex);
        
        IsButtonOff();
        selector.transform.SetParent(currentButton);
        button = currentButton.gameObject;
        IsButtonOn();

        yield return new WaitForSeconds(0.2f);
        isChoosing = false;
    }

    private void IsButtonOff()
    {
        TextManager.instance.ChangeColor(FindChildbyName("Button Text"), previousColor[0]);
        ImageManager.instance.ChangeColor(FindChildbyName("Button Main"), previousColor[1]);

        previousColor.Clear();
    }

    private void IsButtonOn()
    {
        previousColor = new List<Color32>();

        var previousColorText = TextManager.instance.ChangeColor(FindChildbyName("Button Text"), 200, 50, 50);
        var previousColorImage = ImageManager.instance.ChangeColor(FindChildbyName("Button Main"), 220, 145, 145);

        previousColor.Add(previousColorText);
        previousColor.Add(previousColorImage);
    }

    public void SendData()
    {
        switch(selector.transform.parent.name)
        {
            case "ButtonAttack":
                break;
        }
    }   
}