using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Megumin.FileSystem;
using Megumin.GameSystem;
using Megumin.Battle;
using UnityEngine.Rendering;

public class BattleSystem : MonoBehaviour
{
    private JsonConverter jc;
    private List<SerealizableButton> buttons;
    private List<MainCharacter> characters;
    private List<Enemy> enemies;
    private Party party;
    private PartyEnemy partyEnemy;

    private CombatStatus combatStatus;
    private ChoiceStatus choiceStatus;

    private IBattleScreen battleScreen;
    private GameObject[] buttonsObj;

    private UserInput userInput;
    private int userInputNum;

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
        characters = jc.FileToJsonArray1D<MainCharacter>(Path.pathCharacter);
        enemies = jc.FileToJsonArray1D<Enemy>(Path.pathEnemy);
    }

    public void SetUpParty()
    {
        party = jc.FileToJson<Party>(Path.pathParty);
    }

    public void SetUpStatus()
    {
        combatStatus = CombatStatus.CHOICE;
        choiceStatus = ChoiceStatus.MAIN;
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
        startSetScreen.SetCharacter(party);
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
        }
        localButton.actionClick += battleScreen.Close;
        localButton.actionClick += StatusChoice;
    }

    private void UserInputCheck()
    {
        switch(userInputNum)
        {
            case -1:
                return;
            default:
                battleScreen.ButtonDo(userInputNum);
                userInputNum = -1;
                break;
        }
    }

    private void SetUpUserInput()
    {
        userInput = GetComponent<UserInput>();
    }

    private void GoActionChoice()
    {
        choiceStatus = ChoiceStatus.ACTION;
        buttonsObj = null;
    }

    private void GoInfoChoice()
    {
        choiceStatus = ChoiceStatus.INFO;
        buttonsObj = null;
    }
}
