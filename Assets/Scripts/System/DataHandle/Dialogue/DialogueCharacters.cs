using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCharacters : MonoBehaviour, ISetUp
{
    public List<Serialze> serialze;
    public static Dictionary<string, string> dialogueChatactersDictionary;

    [Serializable]
    public class Serialze
    {
        public string tag;
        public string name;
    }

    public void SetUp()
    {
        serialze = TextAssetsManager.instance.FindObjectsByString<Serialze>("dialogue_character");
        
        if(serialze == null)
            Debug.LogError("serial can't be set");
        SetDictionary();
    }

    private void SetDictionary()
    {
        dialogueChatactersDictionary = new Dictionary<string, string>();
        foreach(var single in serialze)
        {
            dialogueChatactersDictionary.Add(single.tag, single.name);
        }
    }

    public string GetName(string tag)
    {
        return dialogueChatactersDictionary[tag];
    }
}
