using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Megumin.GameSystem;
using UnityEditor.EditorTools;

// If you need to set the crossing scenes spawn point you can use this behaviour
public class SpawnPoint : MonoBehaviour
{
    [Tooltip("Choose the tag to set up the spawn point.")]
    public TransportTag transportTag;
    
    [Tooltip("Set the moveX to set where player looks horizentally.")]
    [Range(-1f, 1f)]
    public float moveX;

    [Tooltip("Set the moveY to set where player looks Vetically.")]
    [Range(-1f, 1f)]
    public float moveY;
}
