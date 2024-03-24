using System.Collections;
using System.Collections.Generic;
using Megumin.GameSystem;
using UnityEngine;
using Megumin.DataStructure;

namespace Megumin.Battle
{
    public class TeamUI : MonoBehaviour
    {
        public GameObject prefabToggle;
        private GameObject[] toggles; // toggles will put on all targets

        [Tooltip("Put the parent of the two teams")]
        public GameObject firstParent; // main character team's parent
        public GameObject secondParent; // enemies team's parent

        private TeamChoice teamChoice;
        private int currentTeamAmount; // calculate the amount of one team

        // memebers from firstParent or secondParent
        private GameObject[] members; 

        public void SetUp(TeamChoice teamChoice)
        {
            Reset();
            this.teamChoice = teamChoice;
            SetTeamToggle();
        }

        // set the toggle on the team
        public void SetTeamToggle()
        {
            if(teamChoice == TeamChoice.TEAM_FRIENDLY)
                SetToggle(firstParent, "Characters");
            else if(teamChoice == TeamChoice.TEAM_UNFRIENDLY)
                SetToggle(secondParent, "Enemies");
        }

        private void SetToggle(GameObject team, string teamName)
        {
            GameObjectFind gameObjectFind = new GameObjectFind();
            members = gameObjectFind.FindDecendantTag(team, teamName);

            int i = 0;
            toggles = new GameObject[members.Length];
            foreach(var member in members)
            {
                toggles[i++] = Instantiate(prefabToggle, member.transform);
            }
        }

        public void Reset()
        {
            if(toggles != null)
                foreach(var toggle in toggles) Destroy(toggle);
            toggles = null;
            members = null;
        }
    }

}
