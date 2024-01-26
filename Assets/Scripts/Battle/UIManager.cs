using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Camera[] cameras;
    public GameObject[] gameObjects;

    public void SetUIOnAndOff(Status currentStatus)
    {
        SetAllUIOff();

        switch(currentStatus)
        {
            case Status.SKILL_CHOOSE:
                cameras[0].enabled = true;
                break;
            case Status.ENEMY_CHOOSE:
                gameObjects[0].GetComponent<Renderer>().enabled = true;
                gameObjects[0].transform.GetChild(0).GetComponent<Renderer>().enabled = true;
                break;
        }
    }

    private void SetAllUIOff()
    {
        foreach(var data in cameras)
        {
            data.enabled = false;
        }

        foreach(var data in gameObjects)
        {
            data.GetComponent<Renderer>().enabled = false;
            data.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        }
    }
}
