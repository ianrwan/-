using Megumin.GameSystem;
using Megumin.MeguminException;
using Megumin.DataStructure;
using UnityEngine;

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

        [Header("TeamSet")]
        [Tooltip("teamSetRoot is for the GameObject with team set")]
        [SerializeField]
        private GameObject teamSetRoot;
        private TeamSet teamSet;

        // Check if this item is for team, not for single target
        private bool isTeam;

        // Adjust the the PosRelative2D because of choosing between main charactrers and enemies
        private PosRelative2DAdjust posRelative2DAdjust;

        public void Reset()
        {
            isTeam = false;
        }

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

            TeamChoiceCheck();
            _SetUpInput();
        }

        private void TeamChoiceCheck()
        {
            // according to teamChoice to choose what shoold do
            switch(teamChoice)
            {
                case TeamChoice.FRIENDLY:
                    AdjustPos2D();
                    break;
                case TeamChoice.TEAM_FRIENDLY:
                    MakeTeamSet();
                    break;
                case TeamChoice.UNFRIENDLY:
                    AdjustPos2D();
                    break;
                case TeamChoice.TEAM_UNFRIENDLY:
                    MakeTeamSet();
                    break;
            }
        }

        private void AdjustPos2D()
        {
            // Make main characters and enemies GameObject combine together
            GameObject[] combine = ArrayDealer<GameObject>.CombineArray(localMainCharactersObj, localEnemiesObj);
            posRelative2DAdjust = new PosRelative2DAdjust(combine);

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

        private void MakeTeamSet()
        {
            isTeam = true;
            teamSet = teamSetRoot.GetComponent<TeamSet>();
            teamSet.SetUp(teamChoice);
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

        public override void UserInput(KeyBoard key)
        {
            _LocalDatasExceptionHandle();

            if(isTeam)
            {
                var teamSet = teamSetRoot.GetComponent<TeamSet>();
                teamSet.UserInput(key);
                return;
            }

            switch(key)
            {
                case KeyBoard.RIGHT:
                    _parent.GetComponent<SetToggle>().MoveToggle(key);
                    break;
                case KeyBoard.LEFT:
                    _parent.GetComponent<SetToggle>().MoveToggle(key);
                    break;
                case KeyBoard.UP:
                    _parent.GetComponent<SetToggle>().MoveToggle(key);
                    break;
                case KeyBoard.DOWN:
                    _parent.GetComponent<SetToggle>().MoveToggle(key);
                    break;
                case KeyBoard.Z:
                    _zPress?.Invoke();
                    break;
                case KeyBoard.X:
                    _xPress?.Invoke();
                    break;
            }
        }

        public override void Close()
        {
            if(isTeam)
            {
                teamSet.Close();
                return;
            }

            _toggle.SetActive(false);
        }

        public override void Destroy()
        {
            if(isTeam)
            {
                teamSet.Destroy();
                Reset();
                return;
            }

            Destroy(_toggle);
            posRelative2DAdjust.Reset();
            var setToggle = _parent.GetComponent<SetToggle>();
            setToggle.Init();
        }

        public override void Open()
        {
            if(isTeam)
            {
                teamSet.Open();
                return;
            }

            _toggle.SetActive(true);
        }

        
        protected override void _LocalDatasExceptionHandle()
        {
        }

        protected override void _SetUpInput()
        {
            if(isTeam)
            {
                var endChoice = GetComponent<Click>();
                teamSet.SetInput(endChoice);
                return;
            }

            _zPress = () =>
            {
                var localToggle = _toggle.GetComponent<Toggle>();
                myChoice = localToggle.GetToggleCurrent();
                var endChoice = GetComponent<Click>();
                Destroy();
                endChoice.Do();
            };
        }

        GameObject IGetUpperData<GameObject>.GetData()
        {
            if(isTeam)
            {
                myChoice = teamSet.target;
            }
            return myChoice;
        }
    }
}

