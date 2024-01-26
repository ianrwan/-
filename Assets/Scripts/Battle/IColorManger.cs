using UnityEngine;

public interface IColorManager
{
    public Color32 ChangeColor(GameObject thisObject, byte r, byte g, byte b, byte a);
    public Color32 ChangeColor(GameObject thisObject, Color32 thisColor);
}





