using System.Collections;
using System.Collections.Generic;
using Megumin.GameSystem;
using UnityEngine;

public class SceneGlobal : MonoBehaviour
{
    // Handel the scene where to go to after passing scene over.
    public static string goScene;
    
    // Handle the scene where to go to and set the player on correct position.
    public static TransportTag transportTag;

    public TransportTag peek = transportTag;
}
