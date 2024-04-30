using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeleteGameObject : MonoBehaviour
{
    public GameObject delete;

    private void Awake()
    {
        delete = GameObject.Find("AudioManagerGlobal");
    }
}
