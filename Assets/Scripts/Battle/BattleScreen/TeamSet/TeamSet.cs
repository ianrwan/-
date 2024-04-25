using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Megumin.GameSystem;

namespace Megumin.Battle
{
    public class TeamSet : MonoBehaviour
    {
        [Tooltip("root is for the GameObject with team set")]
        [SerializeField]
        private GameObject root;

        // To put the switch of the team, usually used as Team_Friendly and Team_Unfriendly switch
        private GameObject charactersTeamButton;
        private GameObject enemiesTeamButton;
        public GameObject toggle;

        // Set what to do when Z and X key Press
        private System.Action zPress;
        private System.Action xPress;

        // The target team user chose (after z press)
        // If target PosRelative2D y = 0 => mainCharacters, y = 1 => enemies
        public GameObject target{get; private set;}

        // teamUI is set the UI of the team (like each members in a team should be chose)
        private TeamUI teamUI;

        // teamChoice is from user input
        private TeamChoice teamChoice;
        // currentTeamChoice is from user switch the key horizentally
        private TeamChoice currentTeamChoice;

        public void SetUp(TeamChoice teamChoice)
        {
            this.teamChoice = teamChoice;
            currentTeamChoice = teamChoice;
            SetToggle();
            SetTeamUI();
        }

        private void SetTeamUI()
        {
            teamUI = GetComponent<TeamUI>();
            teamUI.SetUp(teamChoice);
        }

        // It will send the opsite teamchoice to teamUI, input TEAM_FRIENDLY and send in TEAM_UNFRIENDLY 
        // teamChoice will be current teamChoice
        private void SetTeamUIReverse(TeamChoice teamChoice, KeyBoard key)
        {
            // Check if the input is out of the range (TEAM_UNFRIENDLY is a rightmost option)
            if((key == KeyBoard.RIGHT && teamChoice == TeamChoice.TEAM_UNFRIENDLY) || 
                (key == KeyBoard.LEFT && teamChoice == TeamChoice.TEAM_FRIENDLY))
                    return;

            currentTeamChoice = (teamChoice == TeamChoice.TEAM_FRIENDLY) ? TeamChoice.TEAM_UNFRIENDLY : TeamChoice.TEAM_FRIENDLY;
            teamUI.SetUp(currentTeamChoice);
        }

        private void SetToggle()
        {
            var setToggle = root.GetComponent<SetToggle>();

            if(teamChoice == TeamChoice.TEAM_FRIENDLY)
                setToggle.SetToggleOnFirstItem(0 ,0);
            else if(teamChoice == TeamChoice.TEAM_UNFRIENDLY)
                setToggle.SetToggleOnFirstItem(0 ,1);

            toggle = setToggle.toggle;
        }

        public void UserInput(KeyBoard key)
        {
            switch(key)
            {
                case KeyBoard.RIGHT:
                    root.GetComponent<SetToggle>().MoveToggle(key);
                    SetTeamUIReverse(currentTeamChoice, key);
                    break;
                case KeyBoard.LEFT:
                    root.GetComponent<SetToggle>().MoveToggle(key);
                    SetTeamUIReverse(currentTeamChoice, key);
                    break;
                case KeyBoard.UP:
                    root.GetComponent<SetToggle>().MoveToggle(key);
                    break;
                case KeyBoard.DOWN:
                    root.GetComponent<SetToggle>().MoveToggle(key);
                    break;
                case KeyBoard.Z:
                    zPress?.Invoke();
                    break;
                case KeyBoard.X:
                    xPress?.Invoke();
                    break;
            }
        }

        // set the input of zPress and xPress
        // input parameter: click is the component from main system (ex battle system)
        public void SetInput(Click click)
        {
            zPress = () => 
            {
                var toggleComponent = toggle.GetComponent<Toggle>();
                target = toggleComponent.GetToggleCurrent();
                Destroy();
                click.Do();
            };
        }

        public void Close()
        {
            toggle.SetActive(false);
        }

        public void Destroy()
        {
            Destroy(toggle);
            teamUI.Reset();
            var setToggle = root.GetComponent<SetToggle>();
            setToggle.Init();
        }

        public void Open()
        {
            toggle.SetActive(true);
        }
    }
}

