using System.Collections.Generic;
using Megumin.GameSystem;
using UnityEngine;

public class Guard
{
    public int index{get; private set;} //Get The wrong index in List or Array, if index = -1, no wrong
    public string message{get; private set;} // Get The wrong message

    public Guard()
    {
        index = -1;
        message = "";
    }

    public void Reset()
    {
        index = -1;
        message = "";
    }

    public bool IsNoComponent<T>(List<GameObject> list)
    {
        for(int i = 0 ; i < list.Count ; i++)
            if(list[i].GetComponent<LocalEnemy>() == null)
            {
                index = i;
                message = "No component in List, index: "+index;
                return true;
            }
        Reset();
        return false;
    }

    public bool IsElementMissing<T>(List<T> list)
    {
        for(int i = 0 ; i < list.Count ; i++)
            if(list[i] == null)
            {
                index = i;
                message = "Element is Missing in List, index: "+index;
                return true;
            }
        Reset();
        return false;
    }

    public bool IsElementMissing<T>(T[] array)
    {
        for(int i = 0 ; i < array.Length ; i++)
            if(array[i] == null)
            {
                index = i;
                message = "Element is Missing in Array, index: "+index;
                return true;
            }
        Reset();
        return false;
    }
}
