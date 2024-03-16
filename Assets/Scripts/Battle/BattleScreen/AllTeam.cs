using Megumin.Battle;
using Megumin.GameSystem;
using Megumin.MeguminException;
using UnityEngine;

public class AllTeam : BattleScreen
{
    public GameObject parentSecond;
    private TeamChoice teamChoice;

    public override void SetUp(BattleHandleData handleData)
    {
        // if(handleData.partyEnemy == null)
        //         throw new SetUpException("partyEnemy in BattleHandleData doesn't set up");

        // PartyEnemy party = handleData.partyEnemy;
        // __enemiesGameObj = party.enemiesObj;
        // __localEnemies = GameObjectConverter.GetListGameObjComponent<LocalEnemy>(__enemiesGameObj);
        // __SetUpToggle();
        // _SetUpInput();
    }

    public override void ShowText()
    {
        throw new System.NotImplementedException();
    }

    protected override void _LocalDatasExceptionHandle()
    {
        throw new System.NotImplementedException();
    }

    protected override void _SetUpInput()
    {
        throw new System.NotImplementedException();
    }
}
