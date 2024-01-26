using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleController: MonoBehaviour
{
    public Action ChangeStatus;
    public Action PreviousStatus;

    public void HandleUpdateOptionSkill()
    {
        if(Input.GetKey(KeyCode.DownArrow))
        {
            StartCoroutine(OptionManager.instance.MoveSelector(1));
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            StartCoroutine(OptionManager.instance.MoveSelector(0));
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            ChangeStatus?.Invoke();
        }
    }

    public void HandleUpdateOptionEnemy()
    {
        if(Input.GetKey(KeyCode.DownArrow))
        {
            StartCoroutine(OptionManagerEnemy.instance.MoveSelector(1));
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            StartCoroutine(OptionManagerEnemy.instance.MoveSelector(0));
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            ChangeStatus?.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            OptionManager.instance.Reset();
            OptionManager.instance.Start();
            PreviousStatus?.Invoke();
        }
    }
}