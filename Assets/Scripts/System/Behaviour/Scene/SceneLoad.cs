using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public static SceneLoad instance{get; private set;}
    
    public bool isSceneLoad{get; private set;} 

    private void Awake()
    {
        instance = this;
        isSceneLoad = false;
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
        isSceneLoad = true;
    }

    public void DeleteScene(string name)
    {
        StartCoroutine(WaitSceneDelete(name));
    }

    private IEnumerator WaitSceneDelete(string name)
    {
        yield return new WaitForEndOfFrame();
        SceneManager.UnloadSceneAsync(name);

        isSceneLoad = false;
    }
}
