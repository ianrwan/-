using System.Collections;
using System.Collections.Generic;
using Megumin.Battle;
using UnityEngine;

namespace Megumin.Battle
{
    public class Change : BattleScreen
    {
        // put the GameObject ont
        public GameObject prefabSelectCharacters;
        private GameObject currentMainCharacter;

        public override void SetUp(BattleHandleData battleHandleData)
        {
            // currentMainCharacter = battleHandleData.CurrentMainCharacter;    
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

}
