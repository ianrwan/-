// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// using Megumin.FileSystem;

// public class TestJson : MonoBehaviour
// {
//     public TestHandle testHandle;
//     void Start()
//     {
//         JsonConverter jc = new JsonConverter();
//         testHandle = new TestHandle();

//         jc.JsonSaveToFile<TestHandle>(testHandle, @"C:\Users\Ianwa\Documents\作業\畢業專題\廢材勇者_Project\RPG Test\Assets\Scripts\Test\Test.json");
//         var data = jc.FileToJson<TestHandle>(@"C:\Users\Ianwa\Documents\作業\畢業專題\廢材勇者_Project\RPG Test\Assets\Scripts\Test\Test.json");
//         Debug.Log("jsonConvert: "+data);
//     }
// }
