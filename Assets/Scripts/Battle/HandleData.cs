using System;
using UnityEngine;

[Serializable]
public class HandleData
{
    public int choiceButton;

    public int choiceEnemy;
    public GameObject enemyGameObject;

    public Character[] character;
    public GameObject[] characterGameObjects;

    public bool isCoroutineStop;
}
