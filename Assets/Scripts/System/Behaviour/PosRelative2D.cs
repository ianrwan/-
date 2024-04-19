using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosRelative2D : MonoBehaviour
{
    // 將左上角設定為 (0, 0)、x 正向向右、y 正向向下
    public uint x;
    public uint y;

    // if isOff = false, then PosRelative is allowed to access, adjust, or be used
    // if isOff = true, then PosRelative isn't allowed to access, adjust, or be used 
    public bool isOff = false;
}
