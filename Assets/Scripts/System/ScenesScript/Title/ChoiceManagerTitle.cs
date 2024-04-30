using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceManagerTitle : MonoBehaviour
{
    public void NewGame()
    {
        SceneGlobal.goScene = "Preface";
        SceneManager.LoadScene("Passing");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
