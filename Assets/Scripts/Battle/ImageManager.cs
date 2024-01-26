using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour, IColorManager
{
    public static ImageManager instance{get; private set;}

    private void Awake()
    {
        instance = this;
    }

    public Color32 ChangeColor(GameObject thisObject, byte r, byte g, byte b, byte a = 255) 
    {
        Image buttonImage;
        buttonImage = thisObject.GetComponent<Image>();
        var previousColor = buttonImage.color; 

        buttonImage.color = new Color32(r, g, b, a);
        return previousColor;
    }

    public Color32 ChangeColor(GameObject thisObject, Color32 thisColor)
    {
        Image image = thisObject.GetComponent<Image>();
        var previousColor = image.color;

        image.color = new Color32(thisColor.r, thisColor.g, thisColor.b, thisColor.a);
        return previousColor;
    }
}