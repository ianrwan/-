using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlowerTrigger : MonoBehaviour
{
    [SerializeField] public FlowerMissionStage stage;

    public bool isPlayerCollide{get; private set;}

    protected virtual void Update()
    {
        // if(!isPlayerCollide)
        //     return;

        // if(InputManager.instance.isInteract)
        //     StartFlower();
    }


    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.tag == "Player")
            isPlayerCollide = true;
        
    } 

    private void OnCollisionExit2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.tag == "Player")
            isPlayerCollide = false;
    }


    public void StartFlower()
    {   
        if(StageHandlerGlobal.instance.flowerMissionStage == stage)
        {
            StageHandlerGlobal.instance.flowerMissionStage = FlowerMissionStage.FINISH;
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        FlowerSystem.instance.Choise();
    }
}
