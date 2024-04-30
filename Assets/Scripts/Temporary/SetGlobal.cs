using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGlobal : MonoBehaviour
{
    private void Start()
    {
        StageHandlerGlobal.instance.health = 10;       
    }
}
