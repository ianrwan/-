using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArithmeticSystem : MonoBehaviour
{
    public float speed;
    public IEnumerator MakeAnimation(HandleData handleData)
    {
        float animationTime = 0;

        if(handleData.choiceButton == 0)
            animationTime = 0.1f;
        else if(handleData.choiceButton == 1)
            animationTime = 1f;

        handleData.character[0].SetAnime((AnimationStatus)handleData.choiceButton+1);
        handleData.character[0].animeCharacter?.Invoke();

        yield return new WaitForSeconds(animationTime);

        handleData.character[0].SetAnime(0);
        handleData.character[0].animeCharacter?.Invoke();

        handleData.isCoroutineStop = true;
    }

    public IEnumerator VectorCalculate(HandleData handleData)
    {
        var charPos = handleData.characterGameObjects[0].transform.position;
        var enemyPos = handleData.enemyGameObject.transform.position;
        enemyPos -= new Vector3(1f, 0, 0);

        if(handleData.choiceButton == 1)
            enemyPos += new Vector3(0, 0.5f, 0);

        speed = 50f;
        while((enemyPos-charPos).sqrMagnitude > Mathf.Epsilon)
        {
            Debug.Log(charPos);
            handleData.characterGameObjects[0].transform.position = Vector3.MoveTowards(charPos, enemyPos, speed*Time.deltaTime);
            charPos = handleData.characterGameObjects[0].transform.position;
            yield return new WaitForSeconds(0.01f);
        }
        handleData.characterGameObjects[0].transform.position = enemyPos;

        handleData.isCoroutineStop = true;
    }

    public IEnumerator VectorCalculateBack(HandleData handleData)
    {
        var charPos = handleData.characterGameObjects[0].transform.position;
        var originalPos = handleData.character[0].position;
        originalPos -= new Vector3(1f, 0, 0);

        if(handleData.choiceButton == 1)
            originalPos += new Vector3(0, 0.5f, 0);

        speed = 50f;
        while((originalPos-charPos).sqrMagnitude > Mathf.Epsilon)
        {
            Debug.Log(charPos);
            handleData.characterGameObjects[0].transform.position = Vector3.MoveTowards(charPos, originalPos, speed*Time.deltaTime);
            charPos = handleData.characterGameObjects[0].transform.position;
            yield return new WaitForSeconds(0.01f);
        }
        handleData.characterGameObjects[0].transform.position = originalPos;
    }

    private void Move(ref Vector3 startPos,ref Vector3 endPos)
    {
        speed = 10;
        while((endPos-startPos).sqrMagnitude > Mathf.Epsilon)
        {
            startPos = Vector3.MoveTowards(startPos, endPos, speed*Time.deltaTime);
        }
        startPos = endPos;
    }

    public static ArithmeticSystem instance{get; private set;}
    private bool isRightMoving = false;
    private bool isLeftMoving = false;
    private float posX1;
    private float posX2;
    private GameObject stickObject;
    private HandleData handleDataGlobal;
    private Coroutine co;
    private Coroutine co2;

    public void Update()
    {
        if(co != null && Input.GetKeyDown(KeyCode.Z))
        {
            handleDataGlobal.isCoroutineStop = true;
            StopCoroutine(co);
        }
        if(co2 != null && Input.GetKeyDown(KeyCode.Z))
        {
            handleDataGlobal.isCoroutineStop = true;
            StopCoroutine(co2);
        }
    }

    public void CheckSkill(HandleData handleData, GameObject stickObject)
    {
        if(handleData.choiceButton == 1)
            SetStick(handleData, stickObject);
        else
            handleData.isCoroutineStop = true;
        this.stickObject = stickObject;
        this.handleDataGlobal = handleData;
    }

    public void SetStick(HandleData handleData, GameObject stickObject)
    {
        stickObject.SetActive(true);
        float x = stickObject.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        float y = stickObject.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;

        stickObject.transform.GetChild(0).transform.position = new Vector3(stickObject.transform.GetChild(2).transform.position.x-x/2, stickObject.transform.GetChild(0).transform.position.y, 0);
        
        var goalX = stickObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().bounds.size.x;

        posX1 = stickObject.transform.GetChild(1).position.x-goalX/2;
        posX2 = stickObject.transform.GetChild(1).position.x+goalX/2;

        co = StartCoroutine(MoveStick(stickObject, x, y));
    }

    public bool checkGoalStick()
    {
        var currentPos = stickObject.transform.GetChild(0).position.x;
        if(currentPos >= posX1 && currentPos <= posX2)
        {
            return true;
        }
        return false;
    }

    private IEnumerator MoveStick(GameObject stickObject, float length, float height)
    {
        int count = 0;
        isRightMoving = true;
        while(true)
        {
            var arrow = stickObject.transform.GetChild(0).gameObject;
            var background = stickObject.transform.GetChild(1).gameObject;

            var startPos = arrow.transform.position;
            var endPos = new Vector3(arrow.transform.position.x+length, arrow.transform.position.y, 0); 

            speed = 100;
            while((endPos-startPos).sqrMagnitude > Mathf.Epsilon)
            {
                stickObject.transform.GetChild(0).position = Vector3.MoveTowards(startPos, endPos, speed*Time.deltaTime);
                startPos = stickObject.transform.GetChild(0).position;
                yield return new WaitForSeconds(0.05f);
            }
            stickObject.transform.GetChild(0).position = endPos;

            co2 = StartCoroutine(MoveStick2(stickObject, length, height));
            yield return new WaitForSeconds(1f);
            count++;
        }
        isRightMoving = false;
    }

    private IEnumerator MoveStick2(GameObject stickObject, float length, float height)
    {
        var arrow = stickObject.transform.GetChild(0).gameObject;
        var background = stickObject.transform.GetChild(1).gameObject;

        var startPos = arrow.transform.position;
        var endPos = new Vector3(arrow.transform.position.x-length, arrow.transform.position.y, 0); 

        speed = 100;
        while((endPos-startPos).sqrMagnitude > Mathf.Epsilon)
        {
            stickObject.transform.GetChild(0).position = Vector3.MoveTowards(startPos, endPos, speed*Time.deltaTime);
            startPos = stickObject.transform.GetChild(0).position;
            yield return new WaitForSeconds(0.05f);
        }
        stickObject.transform.GetChild(0).position = endPos;
    }
}
