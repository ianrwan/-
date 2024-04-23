using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class TitleButton : MonoBehaviour
{
    public string code{get; private set;}
    public new string name{get; private set;}
    public UnityEvent action;

    public void SetUp(TitleButtons.Serialze serialze)
    {
        code = serialze.code;
        name = serialze.name;

        SetText();
    }

    private void SetText()
    {
        GetComponent<Text>().text = name;   
    }
}
