using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Megumin.FileSystem;
using Megumin.GameSystem;
using Megumin.Battle;

public class BattleSystem : MonoBehaviour
{
    private BattleHandleData battleHandleData;

    private CombatStatus combatStatus;
    private ChoiceStatus choiceStatus;

    private BattleScreen battleScreen;
    private GameObject[] buttonsObj;

    private UserInput userInput;
    private KeyBoard userInputNum;

    private Stack<ChoiceStatus> choiceStatusStack;

    public void Start()
    {
        SetUpList();
        SetUpParty();
        SetUpStatus();
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
        battleHandleData = new BattleHandleData();
    }

    public void SetUpParty()
    {
        SetCharacter setCharacter = GetComponent<SetCharacter>();
        VectorHandle vectorHandle = new MainCharacterVectorHandle(battleHandleData.party.characters.Count);
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
        }
    }

    public void SetUpScreen()
    {
        battleScreen.SetUp(battleHandleData);
        battleScreen.ShowText();

        //暫時使用
        switch(choiceStatus)
        {
            case ChoiceStatus.MAIN:
                SetUpButton();
                break;
            case ChoiceStatus.ACTION:
                SetUpButton();
                break;
        }
    }

    private void SetUpButton()
    {
        buttonsObj = battleScreen.GetGameObjects();

        foreach(var singleButton in buttonsObj)
        {
            var localButton = singleButton.GetComponent<LocalButton>();
            __SetActionInCurrent(localButton);
            ButtonNum(localButton.status, localButton);
        }
    }

    private void __SetActionInCurrent(LocalButton localButton)
    {
        switch(choiceStatus)
        {
            case ChoiceStatus.ACTION:
                IButtonChoice buttonScreen = (Action)battleScreen;
                localButton.actionClick += () =>
                {
                    battleHandleData.playerAction = buttonScreen.GetButtonChoice();
                };
                break;
        }
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

    private void UserInputCheck()
    {
        switch(userInputNum)
        {
            case KeyBoard.NULL:
                return;
            case KeyBoard.X:
                __ReturnBack();
                userInputNum = KeyBoard.NULL;
                break;
            default:
                battleScreen.UserInput(userInputNum);
                userInputNum = KeyBoard.NULL;
                break;
        }
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
