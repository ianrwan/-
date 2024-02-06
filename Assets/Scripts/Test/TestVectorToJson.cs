using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject obj;
    public Vector3 objVector;

    public void Start()
    {
        objVector = obj.GetComponent<RectTransform>().anchoredPosition;
        string data = JsonConvert.SerializeObject(objVector, Formatting.Indented);
        Debug.Log("json vector"+data);
    }
}
