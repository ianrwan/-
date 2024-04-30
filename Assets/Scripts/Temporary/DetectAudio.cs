using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAudio : MonoBehaviour
{
    public bool isPlay;

    public bool isStop;

    public void Start()
    {
        var global = GameObject.Find("AudioManagerGlobal").GetComponent<AudioManagerGlobal>();
        if(isPlay)
            global.Play("normal");
        else
            global.Stop("normal");
    }
}
