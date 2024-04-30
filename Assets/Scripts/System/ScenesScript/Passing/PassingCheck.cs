using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassingCheck : MonoBehaviour
{
    [Tooltip("Input the scene you want to go to.")]
    public string accessScene;
    public int secondTowait;

    [Tooltip("Clear the global on first.")]
    public bool isGlobalClear;

    [Tooltip("Keep your global scene data and not to be deleted.")]
    public bool isKeepGlobalSceneData;

    public void Awake()
    {
        if(SceneGlobal.goScene == "" || SceneGlobal.goScene == null)
        {
            SceneGlobal.goScene = "Title";
        }
    }

    public void Start()
    {
        Debug.Log(SceneGlobal.goScene);
        if(accessScene == "" || accessScene == null)
            accessScene = SceneGlobal.goScene;

        if(isGlobalClear)
            GlobalClear();

        if(!isKeepGlobalSceneData)
            SceneGlobal.goScene = "";

        StartCoroutine(WaitLoadScene());
    }

    public IEnumerator WaitLoadScene()
    {
        yield return new WaitForSeconds(secondTowait);
        Debug.Log(SceneGlobal.goScene);
        SceneManager.LoadScene(accessScene);
    }

    private void GlobalClear()
    {
        if(!isKeepGlobalSceneData)
            SceneGlobal.goScene = "";
        SceneGlobal.transportTag = Megumin.GameSystem.TransportTag.NULL;

        StageHandlerGlobal.instance.Init();
        SpecialEventsControl.Reset();
    }
}
