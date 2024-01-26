using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour, IColorManager
{
    public static TextManager instance{get; private set;}

    private void Awake()
    {
        instance = this;
    }

    public Color32 ChangeColor(GameObject thisObject, byte r, byte g, byte b, byte a = 255) 
    {
        Text buttonText;
        buttonText = thisObject.GetComponent<Text>();
        var previousColor = buttonText.color; 

        buttonText.color = new Color32(r, g, b, a);
        return previousColor;
    }

    public Color32 ChangeColor(GameObject thisObject, Color32 thisColor)
    {
        Text text = thisObject.GetComponent<Text>();
        var previousColor = text.color;

        text.color = new Color32(thisColor.r, thisColor.g, thisColor.b, thisColor.a);
        return previousColor;
    }
}