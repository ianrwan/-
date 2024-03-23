using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Megumin.FileSystem;
using Megumin.GameSystem;
using Megumin.Battle;
using Unity.VisualScripting;

public class BattleSystem : MonoBehaviour
{
    private BattleHandleData battleHandleData;
    private ArithmeticHandleData arithmeticHandleData;

    private CombatStatus combatStatus;
    private ChoiceStatus choiceStatus;

    private BattleScreen battleScreen;
    private GameObject[] buttonsObj;

    private UserInput userInput;
    private KeyBoard userInputNum;

    private BattleArithmetic battleArithmetic;

    private Stack<ChoiceStatus> choiceStatusStack;

    public void Start()
    {
        SetUpList();
        SetUpParty();
        SetUpStatus();
        SetUpScreen();
        SetUpUserInput();
        SetUpArithmetic();
    }

    public void Update()
    {
        userInputNum = userInput.HandleUpdate();
        UserInputCheck();
        CheckArithmetic();
    }

    public void Reset()
    {
        combatStatus = CombatStatus.CHOICE;

        int statckNum = choiceStatusStack.Count;
        for(int i = 1 ; i < statckNum; i++)
            ReturnBack();
        SetUpStatus();
    }

    public void SetUpList()
    {
        battleHandleData = new BattleHandleData();
    }

    public void SetUpParty()
    {
        SetCharacter setCharacter = GetComponent<SetCharacter>();
        battleHandleData.party = setCharacter.SetParty(battleHandleData.partySerial.party ,battleHandleData.dictionarySet);
        VectorHandle vectorHandle = new MainCharacterVectorHandle(battleHandleData.party.GetPartyListSerial().Count);
        setCharacter.SetUpParty(battleHandleData.party, vectorHandle.GetVectorDatas(Path.BattleSystem.battleCharacterVector));

        battleHandleData.partyEnemy = new PartyEnemy();
        SetEnemy setEnemy = GetComponent<SetEnemy>();
        vectorHandle = new EnemyVectorHandle(battleHandleData.partyEnemy.Amount);
        setEnemy.SetUpParty(battleHandleData, vectorHandle.GetVectorDatas(Path.BattleSystem.battleEnemyVector));
    }

    public void SetUpStatus()
    {
        combatStatus = CombatStatus.CHOICE;
        choiceStatus = ChoiceStatus.MAIN;
        choiceStatusStack = new Stack<ChoiceStatus>();
        choiceStatusStack.Push(choiceStatus);
        StatusChoice();
    }

    private void StatusChoice()
    {
        switch(combatStatus)
        {
            case CombatStatus.CHOICE:
                break;
            case CombatStatus.ARITHMETIC:
                battleArithmetic.On();
                break;
        }

        switch(choiceStatus)
        {
            case ChoiceStatus.MAIN:
                battleScreen = GetComponent<Main>();
                break;
            case ChoiceStatus.ACTION:
                battleScreen = GetComponent<Action>();
                break;
            case ChoiceStatus.ENEMY:
                battleScreen = GetComponent<Enemy>();
                break;
            case ChoiceStatus.ITEM:
                battleScreen = GetComponent<Item>();
                break;
            case ChoiceStatus.ALL_TEAM:
                battleScreen = GetComponent<AllTeam>();
                SetUpScreen();
                break;
        }
    }

    public void SetUpScreen()
    {
        battleScreen.SetUp(battleHandleData);
        battleScreen.ShowText();
        switch(choiceStatus)
        {
            case ChoiceStatus.MAIN:
                battleScreen.Open();
                SetUpButton();
                break;
            case ChoiceStatus.ACTION:
                SetUpButton();
                break;
        }

        SetUpClick();
    }

    private void SetUpClick()
    {
        switch(choiceStatus)
        {
            case ChoiceStatus.ITEM:
                EndChoice();
                break;
            case ChoiceStatus.ENEMY:
                EndChoice();
                break;
            case ChoiceStatus.ALL_TEAM:
                EndChoice();
                break;
        }
    }

    private void SetUpButton()
    {
        buttonsObj = battleScreen.GetGameObjects();

        foreach(var singleButton in buttonsObj)
        {
            var localButton = singleButton.GetComponent<LocalButton>();
            SetActionInCurrent(localButton);
            ButtonNum(localButton.status, localButton);
        }
    }

    private void SetActionInCurrent(LocalButton localButton)
    {
        switch(choiceStatus)
        {
            case ChoiceStatus.ACTION:
                IGetUpperData<ButtonChoice> buttonScreen = (Action)battleScreen;
                localButton.actionClick += () =>
                {
                    arithmeticHandleData.combatChoice = buttonScreen.GetData();
                };
                break;
        }
    }

    private void EndChoice()
    {
        IGetUpperData<GameObject> screen;
        Click endChoice = GetComponent<Click>();

        switch(choiceStatus)
        {
            case ChoiceStatus.ENEMY:
                screen = (Enemy)battleScreen;
                endChoice.actionClick = () => {arithmeticHandleData.enemy = screen.GetData();};
                endChoice.actionClick += GoArithmetic;
                break;
            case ChoiceStatus.ITEM:
                screen = (Item)battleScreen;
                endChoice.actionClick = () => {arithmeticHandleData.SetUpTool(screen.GetData());};
                IGetUpperData<TeamChoice> teamChoice = (Item)battleScreen;
                endChoice.actionClick += () => {battleHandleData.teamChoice = teamChoice.GetData();};
                endChoice.actionClick += GoAllTeam;
                break;
            case ChoiceStatus.ALL_TEAM:
                screen = (AllTeam)battleScreen;
                endChoice.actionClick = () => {arithmeticHandleData.target = screen.GetData();};
                endChoice.actionClick += GoArithmetic;
                break;
        }
        
        endChoice.actionClick += battleScreen.Close;
        endChoice.actionClick += StatusChoice;
    }

    private void ButtonNum(ButtonChoice status, LocalButton localButton)
    {
        switch(status)
        {
            case ButtonChoice.BATTLE_START_BATTLE:
                localButton.actionClick += GoActionChoice;
                break;
            case ButtonChoice.BATTLE_INFO:
                localButton.actionClick += GoInfoChoice;
                break;
            case ButtonChoice.BATTLE_ATTACK:
                localButton.actionClick += GoEnemyChoice;
                break;
            case ButtonChoice.BATTLE_SPECIAL_ATTACK:
                localButton.actionClick += GoSmallGame;
                break;
            case ButtonChoice.BATTLE_ITEM:
                localButton.actionClick += GoItemChoice;
                break;
            case ButtonChoice.BATTLE_DEFENCE:
                localButton.actionClick += GoArithmetic;
                break;
            case ButtonChoice.BATTLE_RETREAT:
                localButton.actionClick += GoArithmetic;
                break;
            case ButtonChoice.BATTLE_CHANGE:
                localButton.actionClick += GoChangeChoice;
                break;
        }

        localButton.actionClick += battleScreen.Close;
        localButton.actionClick += StatusChoice;
        localButton.actionClick += SetUpScreen;
    }

    private void SetUpArithmetic()
    {
        arithmeticHandleData = new ArithmeticHandleData();
        battleArithmetic = GetComponent<BattleArithmetic>();
        battleArithmetic.SetUp(arithmeticHandleData);
    }

    private void CheckArithmetic()
    {
       
        if(combatStatus != CombatStatus.ARITHMETIC)
            return;

        if(battleArithmetic.isEnd == false)
            return;

        Click end = GetComponent<Click>();
        // end.Do();
        battleArithmetic.Off();
        Reset();
    }

    private void UserInputCheck()
    {
        switch(userInputNum)
        {
            case KeyBoard.NULL:
                return;
            case KeyBoard.X:
                ReturnBack();
                userInputNum = KeyBoard.NULL;
                break;
            default:
                battleScreen.UserInput(userInputNum);
                userInputNum = KeyBoard.NULL;
                break;
        }
    }

    private void ReturnBack()
    {
        if(choiceStatusStack.Count <= 1)
            return;

        battleScreen.Destroy();
        choiceStatusStack.Pop();
        choiceStatus = choiceStatusStack.Peek();
        StatusChoice();
        SetUpClick();
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

    private void GoAllTeam()
    {
        choiceStatus = ChoiceStatus.ALL_TEAM;
        choiceStatusStack.Push(choiceStatus);
    }
}
