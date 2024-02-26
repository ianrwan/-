using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Megumin.FileSystem;
using Megumin.GameSystem;
using Megumin.Battle;
using UnityEditor.Rendering;

public class BattleSystem : MonoBehaviour
{
    private JsonConverter jc;
    private List<SerealizableButton> buttons;
    private List<SerializableMainCharacter> characters;
    private List<Enemy> enemies;
    private Party party;
    private PartyEnemy partyEnemy;

    private CombatStatus combatStatus;
    private ChoiceStatus choiceStatus;

    private IBattleScreen battleScreen;
    private GameObject[] buttonsObj;

    private UserInput userInput;
    private KeyBoard userInputNum;

    private Stack<ChoiceStatus> choiceStatusStack;

    public void Start()
    {
        SetUpList();
        SetUpParty();
        SetUpStatus();
        SetUpEnemy();
        SetUpScreen();
        SetUpUserInput();
    }

    public void Update()
    {
        userInputNum = userInput.HandleUpdate();
        UserInputCheck();
    }

    public void SetUpList()
    {
        jc = new JsonConverter();
        buttons = jc.FileToJsonArray1D<SerealizableButton>(Path.pathButton);
        characters = jc.FileToJsonArray1D<SerializableMainCharacter>(Path.pathCharacter);
        enemies = jc.FileToJsonArray1D<Enemy>(Path.pathEnemy);
    }

    public void SetUpParty()
    {
        party = jc.FileToJson<Party>(Path.pathParty);

        SetCharacter setCharacter = GetComponent<SetCharacter>();
        VectorHandle vectorHandle = new MainCharacterVectorHandle(party.characters.Count);
        setCharacter.SetUpParty(party, vectorHandle.GetVectorDatas(Path.BattleSystem.battleCharacterVector));
    }

    public void SetUpStatus()
    {
        combatStatus = CombatStatus.CHOICE;
        choiceStatus = ChoiceStatus.MAIN;
        choiceStatusStack = new Stack<ChoiceStatus>();
        choiceStatusStack.Push(choiceStatus);
        StatusChoice();
    }

    // 尚未加入區域判斷，怪物判斷
    public void SetUpEnemy()
    {
        int enemyAmount = Random.Range(1, 4);
        partyEnemy = new PartyEnemy();

        for(int i = 0 ; i < enemyAmount ; i++)
        {
            partyEnemy.enemies.Add(enemies[0]);
        }
    }

    public void SetUpScreen()
    {
        StartSetScreen startSetScreen = GetComponent<StartSetScreen>();
        // startSetScreen.SetCharacter(party);
        startSetScreen.SetEnemy(partyEnemy);
        SetUpButton();
    }

    private void StatusChoice()
    {
        switch(choiceStatus)
        {
            case ChoiceStatus.MAIN:
                battleScreen = GetComponent<Main>();
                break;
            case ChoiceStatus.ACTION:
                battleScreen = GetComponent<Action>();
                break;
        }
    }

    private void SetUpButton()
    {
        battleScreen.SetUpButton(buttons);
        battleScreen.ShowButtonText();
        buttonsObj = battleScreen.GetButtonsGameObj();

        foreach(var singleButton in buttonsObj)
        {
            var localButton = singleButton.GetComponent<LocalButton>();
            ButtonNum(localButton.no, localButton);
        }
    }

    private void ButtonNum(int buttonNum, LocalButton localButton)
    {
        switch(buttonNum)
        {
            case 0:
                localButton.actionClick = GoActionChoice;
                break;
            case 1:
                localButton.actionClick = GoInfoChoice;
                break;
            case 2:
                localButton.actionClick = GoEnemyChoice;
                break;
            case 3:
                localButton.actionClick = GoSmallGame;
                break;
            case 4:
                localButton.actionClick = GoItemChoice;
                break;
            case 5:
                localButton.actionClick = GoArithmetic;
                break;
            case 6:
                localButton.actionClick = GoArithmetic;
                break;
            case 7:
                localButton.actionClick = GoChangeChoice;
                break;
        }
        localButton.actionClick += battleScreen.Close;
        localButton.actionClick += StatusChoice;
        localButton.actionClick += SetUpButton;
    }

    private void UserInputCheck()
    {
        switch(userInputNum)
        {
            case KeyBoard.NULL:
                return;
            case KeyBoard.X:
                __ReturnBack();
                break;
            default:
                battleScreen.ButtonDo(userInputNum);
                break;
        }
        userInputNum = KeyBoard.NULL;
    }

    private void __ReturnBack()
    {
        if(choiceStatusStack.Count <= 1)
            return;

        battleScreen.Destroy();
        choiceStatusStack.Pop();
        choiceStatus = choiceStatusStack.Peek();
        StatusChoice();
        battleScreen.Open();
    }

    private void SetUpUserInput()
    {
        userInput = GetComponent<UserInput>();
    }

    private void GoActionChoice()
    {
        choiceStatus = ChoiceStatus.ACTION;
        choiceStatusStack.Push(choiceStatus);
    }

    private void GoInfoChoice()
    {
        choiceStatus = ChoiceStatus.INFO;
        choiceStatusStack.Push(choiceStatus);
    }

    private void GoEnemyChoice()
    {
        choiceStatus = ChoiceStatus.ENEMY;
        choiceStatusStack.Push(choiceStatus);
    }

    private void GoItemChoice()
    {
        choiceStatus = ChoiceStatus.ITEM;
        choiceStatusStack.Push(choiceStatus);
    }

    private void GoChangeChoice()
    {
        choiceStatus = ChoiceStatus.CHANGE;
        choiceStatusStack.Push(choiceStatus);
    }

    private void GoArithmetic()
    {
        combatStatus = CombatStatus.ARITHMETIC;
    }

    private void GoSmallGame()
    {
        combatStatus = CombatStatus.SMALLGAME;
    }
}
