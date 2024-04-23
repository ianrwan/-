using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassingCheck : MonoBehaviour
{
    private string accessScene;
    public int secondTowait;

    public void Start()
    {
        accessScene = SceneGlobal.goScene;
        SceneGlobal.goScene = "";
        StartCoroutine(WaitLoadScene());
    }

    public IEnumerator WaitLoadScene()
    {
        yield return new WaitForSeconds(secondTowait);
        SceneManager.LoadScene(accessScene);
    }
}
