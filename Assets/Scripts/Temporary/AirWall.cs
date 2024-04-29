using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirWall : MonoBehaviour
{
    [Header("Custom")]
    public GameObject player;
    private DialogueTriggerAutoActive dialogueTrigger;
    private TransportTrigger transportTrigger;

    private void Start()
    {
        dialogueTrigger = GetComponent<DialogueTriggerAutoActive>();
        transportTrigger = GetComponent<TransportTrigger>();
    }

    private void Update()
    {
    }

    public void OnTriggerEnter2D()
    {
        if(transportTrigger.isLock == false)
            return;
        dialogueTrigger.TriggerMutipleTime();
        
        StartCoroutine(Move());
    }

    public IEnumerator Move()
    {
        Vector3 targetPos = player.transform.position + new Vector3(5, 0, 0);
        while((targetPos - player.transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos, 20*Time.deltaTime);
            Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, Camera.main.transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
        player.transform.position = targetPos;  
    }
}
