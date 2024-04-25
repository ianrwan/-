using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Scripting;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager instance{get; private set;}

    private string animeTag;
    private string[] animes;

     private void Awake()
    {
        if(instance != null)
            Debug.LogWarning("It's not allowed to set multiple AnimationManager");
        instance = this;
    }

    public bool IsAnimationExist(string tag)
    {
        animeTag = DialogueTagManager.instance.GetTagValue("anime");

        if(animeTag == null)
            return false;
        
        Split(animeTag);

        if(!animes.Contains(tag))
            return false;

        DialogueTagManager.instance.RemoveTag("anime");
        return true;
    }

    private void Split(string tagName)
    {
        animes = tagName.Split(',');

        int index = 0;
        foreach(var anime in animes)
        {
            animes[index++] = anime.Trim();
        }
    }
}
