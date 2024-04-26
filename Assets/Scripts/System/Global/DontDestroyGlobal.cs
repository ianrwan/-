using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Component isn't allowed for the same name of the GameObject.
public class DontDestroyGlobal : MonoBehaviour
{
    // check if the GameObject is existed in the game
    public static List<string> names;

    public void Awake()
    {
        if(names == null)
        {
            names = new List<string>();
        }

        var name = names.Find(name => name == gameObject.name);

        if(name != null)
        {
            Destroy(gameObject);
            return;
        }

        names.Add(gameObject.name);
        DontDestroyOnLoad(this.gameObject);
    }
}
