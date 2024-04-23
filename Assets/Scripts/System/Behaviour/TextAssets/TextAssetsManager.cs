using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Megumin.FileSystem;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Linq;

public class TextAssetsManager : MonoBehaviour
{
    public static TextAssetsManager instance;

    [SerializeField] private TextAsset[] jsonFiles;
    private JObject[] jsonObjects;
    private Dictionary<string, JObject> typeStringMapJObject;

    public bool isLoaded{get; private set;}

    public int Amount
    {
        get
        {
            if(jsonFiles == null)
                return 0;
            return jsonFiles.Length;
        }    
    }

    private void Awake()
    {
        instance = this;
        isLoaded = false;
    }

    private void Start()
    {
        if(jsonFiles == null)
            return;

        SetUpJsonObjects();
    }

    private void SetUpJsonObjects()
    {
        jsonObjects = new JObject[Amount];
        typeStringMapJObject = new Dictionary<string, JObject>();

        int index = 0;
        foreach(var jsonFile in jsonFiles)
        {
            jsonObjects[index] = JObject.Parse(jsonFile.text);
            typeStringMapJObject.Add(jsonObjects[index]["type"].ToString(), jsonObjects[index]);
            index++;
        }

        isLoaded = true;
    }

    public List<T> FindObjectsByString<T>(string name)
    {
        if(typeStringMapJObject == null || !typeStringMapJObject.ContainsKey(name))
            return null;
        Debug.Log("in");
        List<T> list = new List<T>();

        foreach(var data in typeStringMapJObject[name]["data"])
        {
            Debug.Log(data.ToString());
            var temp = JsonConvert.DeserializeObject<T>(data.ToString());
            list.Add(temp);
        }

        return list;
    }
}
