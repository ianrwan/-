using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Megumin.GameSystem;

public class SetGoScene : MonoBehaviour
{
    public TransportTag transportTag;
    private void Start()
    {
        SceneGlobal.transportTag = transportTag;
    }
}
