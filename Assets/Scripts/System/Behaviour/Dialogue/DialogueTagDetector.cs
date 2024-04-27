using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueTagDetector : MonoBehaviour
{
    public static DialogueTagDetector instance{get; private set;}

    private string detectTag;
    private string[] tagValues;
    public int Length
    {
        get => tagValues.Length;
    }

     private void Awake()
    {
        if(instance != null)
            Debug.LogWarning("It's not allowed to set multiple AnimationManager");
        instance = this;
    }

    // Check if the tag request is in dialogue
    public bool IsTagExist(string tag, string value)
    {
        detectTag = DialogueTagManager.instance.GetTagValue(tag);

        if(detectTag == null)
            return false;
        
        Split(detectTag);

        if(!tagValues.Contains(value))
            return false;

        DialogueTagManager.instance.RemoveTag(tag);
        return true;
    }

    private void Split(string tagName)
    {
        tagValues = tagName.Split(',');

        int index = 0;
        foreach(var anime in tagValues)
        {
            tagValues[index++] = anime.Trim();
        }
    }

    // If the index of the value is over and GetValue will return false
    public string GetValue(int index)
    {
        if(tagValues == null || index >= tagValues.Length)
            return null;
        return tagValues[index];
    }
}
