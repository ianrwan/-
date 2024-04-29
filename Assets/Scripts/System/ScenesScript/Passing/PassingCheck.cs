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

    public void Start()
    {
        if(accessScene == "")
            accessScene = SceneGlobal.goScene;

        if(isGlobalClear)
            GlobalClear();

        SceneGlobal.goScene = "";
        StartCoroutine(WaitLoadScene());
    }

    public IEnumerator WaitLoadScene()
    {
        yield return new WaitForSeconds(secondTowait);
        SceneManager.LoadScene(accessScene);
    }

    private void GlobalClear()
    {
        SceneGlobal.goScene = "";
        SceneGlobal.transportTag = Megumin.GameSystem.TransportTag.NULL;

        StageHandlerGlobal.instance.Init();
    }
}
