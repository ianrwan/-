using System;
using System.Collections;
using System.Collections.Generic;
using Megumin.Battle;
using Megumin.DataStructure;
using Megumin.GameSystem;
using Megumin.MeguminException;
using UnityEngine;

namespace Megumin.Battle
{
    public class Enemy : BattleScreen, IGetUpperData<GameObject>
    {
        private GameObject __enemy;
        private List<GameObject> __enemiesGameObj;
        private List<LocalEnemy> __localEnemies;

        public override void SetUp(BattleHandleData handleData)
        {
            if(handleData.partyEnemy == null)
                throw new SetUpException("partyEnemy in BattleHandleData doesn't set up");

            PartyEnemy party = handleData.partyEnemy;
            __enemiesGameObj = party.EnemiesObj;
            __localEnemies = GameObjectConverter.GetListGameObjComponent<LocalEnemy>(__enemiesGameObj);
            __SetUpToggle();
            _SetUpInput();
        }

        private void __SetUpToggle()
        {
            var setToggle = _parent.GetComponent<SetToggle>();
            setToggle.SetToggleOnFirstItem();
            _toggle = setToggle.toggle;
        }

        public override void ShowText()
        {
            return;
        }

        protected override void _SetUpInput()
        {
            _zPress = () =>
            {
                var localToggle = _toggle.GetComponent<Toggle>();
                __enemy = localToggle.GetToggleCurrent();
                var endChoice = GetComponent<Click>();
                Destroy();
                endChoice.Do();
            };
        }

        protected override void _LocalDatasExceptionHandle()
        {
            if(__localEnemies.Count == 0)
                throw new BattleScreenException();
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

        public GameObject GetData()
        {
            return __enemy;
        }
    }
}

