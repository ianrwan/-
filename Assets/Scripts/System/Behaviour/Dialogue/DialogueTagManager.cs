using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTagManager : MonoBehaviour
{
    public static DialogueTagManager instance{get; private set;}
    public List<string> tags{get; private set;}
    
    private string[][] tagsSplit;
    private Dictionary<string, string> tagsDictionary;

    private void Awake()
    {
        if(instance != null)
            Debug.LogWarning("It's not allowed to set multiple DialogueTagManager");
        instance = this;
    }
    
    public void SetTags()
    {
        tags = DialogueManager.currentStroy.currentTags;
        try
        {
            Debug.Log(tags[0]);
        }
        catch(Exception e)
        {
            
        }

        if(tags.Count == 0)
            return;

        tagsSplit = new string[tags.Count][];
        tagsDictionary = new Dictionary<string, string>();

        for(int i = 0 ; i < tags.Count; i++)
        {
            Split(i, tags[i]);
            tagsDictionary.Add(tagsSplit[i][0], tagsSplit[i][1]);
        }
        
    }

    private void Split(int index, string tag)
    {
        tagsSplit[index] = tag.Split(':');
        tagsSplit[index][0] = tagsSplit[index][0].Trim();
        tagsSplit[index][1] = tagsSplit[index][1].Trim();
    }

    public string GetTagValue(string tagNameFind)
    {
        if(tagsDictionary == null)
            return null;

        if(!tagsDictionary.ContainsKey(tagNameFind))
            return null;

        return tagsDictionary[tagNameFind];
    }

    public void RemoveTag(string tagName)
    {
        if(tagsDictionary == null)
            return;

        if(!tagsDictionary.ContainsKey(tagName))
            return;

        tagsDictionary.Remove(tagName);
    }
}
