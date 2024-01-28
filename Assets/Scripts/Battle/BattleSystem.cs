using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Megumin.FileSystem;
using Megumin.GameSystem;
using Megumin.Battle;

public class BattleSystem : MonoBehaviour
{
    private JsonConverter jc;
    private List<Megumin.GameSystem.Button> buttons;
    private List<MainCharacter> characters;
    private List<Enemy> enemies;
    private Party party;
    private PartyEnemy partyEnemy;

    private CombatStatus combatStatus;
    private ChoiceStatus choiceStatus;

    private IBattleScreen battleScreen;
    private List<GameObject> buttonsObj;

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
    }

    public void SetUpList()
    {
        jc = new JsonConverter();
        buttons = jc.FileToJsonArray1D<Megumin.GameSystem.Button>(Path.pathButton);
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

        StatusChoice();
    }

    private void StatusChoice()
    {
        switch(choiceStatus)
        {
            case ChoiceStatus.MAIN:
                battleScreen = GetComponent<Main>();
                break;
        }
        buttonsObj = battleScreen.ShowButtonText(buttons);
        SetUpButton();
    }

    private void SetUpButton()
    {
        foreach(var singleButton in buttonsObj)
        {
            var localButton = singleButton.GetComponent<LocalButton>();
            buttonNum(localButton.no, localButton);
        }
    }

    private void buttonNum(int buttonNum, LocalButton localButton)
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
    }

    private void SetUpUserInput()
    {
        userInput = GetComponent<UserInput>();
    }

    private void GoActionChoice()
    {
        choiceStatus = ChoiceStatus.ACTION;
        buttonsObj.Clear();
    }

    private void GoInfoChoice()
    {
        choiceStatus = ChoiceStatus.INFO;
        buttonsObj.Clear();
    }
}
