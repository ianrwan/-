using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Megumin.FileSystem;
using Megumin.GameSystem;

public class TestUse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        JsonConverter jc = new JsonConverter();
        var list = jc.FileToJsonArray1D<SerializableMainCharacter>(Path.pathCharacter, "data");

        foreach(var data in list)
            Debug.Log("TestUse: "+data.job);
    }
}
