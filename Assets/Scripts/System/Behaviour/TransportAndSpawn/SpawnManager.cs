using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Megumin.DataStructure;
using Megumin.GameSystem;

public class SpawnManager : MonoBehaviour
{

    [Tooltip("Points where to spawn player.")]
    [SerializeField] private GameObject[] spawnAreas;
    private GameObject choiceSpawnArea;

    [Tooltip("Put the player on.")]
    [SerializeField] private GameObject player;
    private Animator playerAnimator;

    private bool isSpawnExist;
    private bool isSpawnPointAccesible;

    private void Start()
    {
        if(player == null || player.tag != "Player")
        {
            Debug.LogError("No player in SpawnManager.");
        }

        if(spawnAreas == null || spawnAreas.Length == 0)
        {
            isSpawnExist = false;
            return;
        }

        isSpawnExist = true;
        SetUp();
    }

    private void SetUp()
    {
        if(SceneGlobal.transportTag == TransportTag.NULL)
            return;

        SpawnPoint spawnAreaPoint = null;
        foreach(var spawnArea in spawnAreas)
        {
            spawnAreaPoint = spawnArea.GetComponent<SpawnPoint>();
            if(spawnAreaPoint.transportTag == SceneGlobal.transportTag)
            {
                choiceSpawnArea = spawnArea;
                isSpawnPointAccesible = true;
                break;
            }
        }

        if(!isSpawnPointAccesible)
        {
            Debug.LogWarning("No SpawnPoint when Accessing. "+SceneGlobal.transportTag);
            return;
        }

        player.transform.position = new Vector2(choiceSpawnArea.gameObject.transform.position.x, choiceSpawnArea.gameObject.transform.position.y);
        playerAnimator = player.GetComponent<Animator>();
        
        playerAnimator.SetFloat("moveX", spawnAreaPoint.moveX);
        playerAnimator.SetFloat("moveY", spawnAreaPoint.moveY);
    }

}
