using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public enum Status{SKILL_CHOOSE, ENEMY_CHOOSE, ARITHMETIC}
public class BattleSystemx : MonoBehaviour
{
    private Status currentStatus;
    private List<Status> previousStatus;
    private Status nextStatus;

    private bool isArithmetic = false;

    [SerializeField]
    private GameObject playerObject;
    private PlayerBattleController playerController;

    public List<GameObject> charactersData; // only for character gameObject
    public HandleData handleData;

    public GameObject stickObject;
    public Vector3 stickArrowPos;

    private void Awake()
    {
        playerController = playerObject.GetComponent<PlayerBattleController>();
    }

    private void Start()
    {
        // stickObject.SetActive(false);
        var x = stickObject.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        Debug.Log(stickObject.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().bounds.size.y);

        stickObject.transform.GetChild(0).transform.position = new Vector3(stickObject.transform.GetChild(2).transform.position.x-x/2, stickObject.transform.GetChild(0).transform.position.y, 0);

        stickArrowPos = stickObject.transform.GetChild(0).position;

        stickObject.SetActive(false);

        handleData = new HandleData();
        SetCharacters();

        previousStatus = new List<Status>();
        currentStatus = Status.SKILL_CHOOSE;
        GetComponent<UIManager>().SetUIOnAndOff(currentStatus);
        SetInitStatusPlayer();
    }

    private void Update()
    {
        switch(currentStatus)
        {
            case Status.SKILL_CHOOSE:
                playerController.HandleUpdateOptionSkill();
                SetNextStatus(Status.ENEMY_CHOOSE);
                break;

            case Status.ENEMY_CHOOSE:
                playerController.HandleUpdateOptionEnemy();
                SetNextStatus(Status.ARITHMETIC);
                break;

            case Status.ARITHMETIC:
                ArithmeticInstance();
                SetNextStatus(Status.SKILL_CHOOSE);
                break;
        }
    }

    private void SetInitStatusPlayer()
    {
        playerController.ChangeStatus = () =>
        {
            
            int listCount = previousStatus.Count;
            if(listCount > 1 && previousStatus[listCount-1] != previousStatus[listCount-2])
            {
                previousStatus.RemoveAt(listCount-1);
                return;
            }
            // 檢查玩家是否快速點擊導致 status 重複算過

            previousStatus.Add(currentStatus);
            currentStatus = nextStatus;
            GetComponent<UIManager>().SetUIOnAndOff(currentStatus);
        };

        playerController.PreviousStatus = () =>
        {
            int listCount = previousStatus.Count;
            nextStatus = currentStatus;
            currentStatus = previousStatus[listCount-1];
            previousStatus.RemoveAt(listCount-1);
            GetComponent<UIManager>().SetUIOnAndOff(currentStatus);
        };
    }

    private void SetNextStatus(Status status)
    {
        if(nextStatus == status)
            return;

        nextStatus = status;
    }

    private void SetCharacters()
    {
        handleData.character = new Character[10];
        handleData.characterGameObjects = new GameObject[10];

        int i = 0;
        foreach(var data in charactersData)
        {
            handleData.character[i] = data.GetComponent<Character>();
            handleData.character[i].position = data.transform.position;
            handleData.characterGameObjects[i] = data;
            i++;
        }
    }

    private void ArithmeticInstance()
    {
        if(isArithmetic == true)
            return;

        isArithmetic = true;
        GetSelector();
        StartCoroutine(SendToArithmeticSystem());
    }

    private void GetSelector()
    {
        var objectFound = GameObject.FindGameObjectsWithTag("Selector");
        foreach(var data in objectFound)
        {
            int temp = data.transform.parent.GetSiblingIndex();
            switch(data.transform.parent.parent.name)
            {
                case "Enemy":
                    handleData.choiceEnemy = temp;
                    handleData.enemyGameObject = GameObject.Find("/Enemy").transform.GetChild(temp).gameObject;
                    Debug.Log("enemy objects "+handleData.enemyGameObject.name);
                    break;
                
                case "Grid":
                    handleData.choiceButton = temp;
                    break;

                default:
                    Debug.LogWarning(temp+" can't be found");
                    break;
            }
        }
    }

    private IEnumerator SendToArithmeticSystem()
    {
        GetComponent<ArithmeticSystem>().CheckSkill(handleData, stickObject);
        yield return new WaitUntil(() => { return handleData.isCoroutineStop;});
        handleData.isCoroutineStop = false;

        if(GetComponent<ArithmeticSystem>().checkGoalStick() || handleData.choiceButton != 1)
        {
            if(GetComponent<ArithmeticSystem>().checkGoalStick())
            {
                yield return new WaitForSecondsRealtime(0.1f);
                stickObject.SetActive(false);
            }

            StartCoroutine(GetComponent<ArithmeticSystem>().VectorCalculate(handleData));
            yield return new WaitUntil(() => { return handleData.isCoroutineStop;});
            handleData.isCoroutineStop = false;

            StartCoroutine(GetComponent<ArithmeticSystem>().MakeAnimation(handleData));
            yield return new WaitUntil(() => { return handleData.isCoroutineStop;});
            handleData.isCoroutineStop = false;
            yield return new WaitForSeconds(1f);

            StartCoroutine(GetComponent<ArithmeticSystem>().VectorCalculateBack(handleData));
        }
        currentStatus = nextStatus;
    }

    private void CheckList()
    {
        string all = "";
        foreach(var data in previousStatus)
        {
            all += data+" ";
        }
        Debug.Log(all);
    }
}
