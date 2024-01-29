// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// using Megumin.FileSystem;
// using Megumin.GameSystem;

// public class TestJson : MonoBehaviour
// {
//     void Start()
//     {
//         JsonConverter jc = new JsonConverter();
//         List<Button> listButton = jc.FileToJsonArray1D<Button>(Application.dataPath+@"\Storage\Button\button.json");

//         foreach(var data in listButton)
//         {
//             Debug.Log(data.no);
//             Debug.Log(data.name);
//         }
//     }
// }
