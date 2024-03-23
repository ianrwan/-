using Megumin.Battle;
using Megumin.GameSystem;
using Megumin.MeguminException;
using Megumin.DataStructure;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Runtime.CompilerServices;

namespace Megumin.Battle
{
    public class AllTeam : BattleScreen, IGetUpperData<GameObject>
    {
        public GameObject firstParent;
        public GameObject secondParent;
        private TeamChoice teamChoice;

        private PartyEnemy partyEnemy;
        private Party partyCharacter;
        private GameObject[] localEnemiesObj;
        private GameObject[] localMainCharactersObj;
        private GameObject myChoice;

        public override void SetUp(BattleHandleData handleData)
        {
            if(handleData.partyEnemy == null)
                    throw new SetUpException("partyEnemy in BattleHandleData doesn't set up");

            partyEnemy = handleData.partyEnemy;
            partyCharacter = handleData.party;

            GameObjectFind gameObjectFind = new GameObjectFind();
            localEnemiesObj = gameObjectFind.FindDecendantComponentIsAttached<PosRelative2D>(secondParent);
            localMainCharactersObj = gameObjectFind.FindDecendantTag(firstParent, "Characters");

            teamChoice = handleData.teamChoice;

            AdjustPos2D();
            _SetUpInput();
        }

        private void AdjustPosRelative2D()
        {
            switch(teamChoice)
            {
                case TeamChoice.FRIENDLY:
                    break;
                case TeamChoice.TEAM_FRIENDLY:
                    break;
                case TeamChoice.UNFRIENDLY:
                    break;
                case TeamChoice.TEAM_UNFRIENDLY:
                    break;
            }
        }

        private void AdjustPos2D()
        {
            GameObject[] combine = ArrayDealer<GameObject>.CombineArray(localMainCharactersObj, localEnemiesObj);
            PosRelative2DAdjust posRelative2DAdjust = new PosRelative2DAdjust(combine);

            uint[][] pos = new uint[combine.Length][];

            int counter = 0;

            for(int i = 0 ; i < localMainCharactersObj.Length ; i++)
            {
                pos[counter] = new uint[2];
                var pos2D = localMainCharactersObj[i].GetComponent<PosRelative2D>();
                pos[counter][0] = pos2D.x;
                pos[counter++][1] = pos2D.y;
            }

            for(int i = 0 ; i < localEnemiesObj.Length ; i++)
            {
                pos[counter] = new uint[2];
                var pos2D = localEnemiesObj[i].GetComponent<PosRelative2D>();
                pos[counter][0] = pos2D.x;
                pos[counter++][1] = 1;
            }

            posRelative2DAdjust.SetData(pos);

            if(teamChoice == TeamChoice.FRIENDLY)
                SetUpToggle(combine, 0, 0);
            else if(teamChoice == TeamChoice.UNFRIENDLY)
                SetUpToggle(combine, 0, 1);
        }

        // 這個是要 TeamChoice.Friendly 跟 TeamChoice.UnFriendly 才會做
        private void SetUpToggle(GameObject[] gameObjects, int x, int y)
        {
            var setToggle = _parent.GetComponent<SetToggle>();
            setToggle.SetToggleOnFirstItemExclude(gameObjects, x, y);
            _toggle = setToggle.toggle;
        }

        public override void ShowText()
        {
            return;
        }

        public override void Close()
        {
            _toggle.SetActive(false);
        }

        public override void Destroy()
        {
            Destroy(_toggle);
            var setToggle = _parent.GetComponent<SetToggle>();
            setToggle.Init();
        }

        public override void Open()
        {
            _toggle.SetActive(true);
        }

        protected override void _LocalDatasExceptionHandle()
        {
            return;
        }

        protected override void _SetUpInput()
        {
            
            _zPress = () =>
            {
                var localToggle = _toggle.GetComponent<Toggle>();
                myChoice = localToggle.GetToggleCurrent();
                var endChoice = GetComponent<Click>();
                endChoice.Do();
            };
        }

        GameObject IGetUpperData<GameObject>.GetData()
        {
            return myChoice;
        }
    }
}

