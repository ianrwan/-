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
    // public class Enemy : MonoBehaviour, IBattleScreen
    // {
    //     public GameObject enemyParent;
    //     private List<GameObject> __enemiesGameObj;
    //     private List<LocalEnemy> __localEnemies;
    //     private GameObject __toggle;

    //     public void SetUpButton(BattleHandleData handleData)
    //     {
    //         if(handleData.partyEnemy == null)
    //             throw new SetUpException("partyEnemy in BattleHandleData doesn't set up");

    //         PartyEnemy party = handleData.partyEnemy;
    //         __enemiesGameObj = party.enemiesObj;
    //         __localEnemies = GameObjectConverter.GetListGameObjComponent<LocalEnemy>(__enemiesGameObj);
    //         __SetUpToggle();
    //     }

    //     private void __SetUpToggle()
    //     {
    //         var setToggle = enemyParent.GetComponent<SetToggle>();
    //         setToggle.SetToggleOnFirstItem();
    //         __toggle = setToggle.toggle;
    //     }

    //     public GameObject[] GetButtonsGameObj()
    //     {
    //         return GameObjectConverter.ListArrayConverter(__enemiesGameObj);
    //     }

    //     public void ShowButtonText()
    //     {
    //         return;
    //     }

    //     public void ButtonDo(KeyBoard key)
    //     {
    //         if(__localEnemies.Count == 0)
    //                 throw new BattleScreenException();

    //         switch(key)
    //         {
    //             case KeyBoard.RIGHT:
    //                 enemyParent.GetComponent<SetToggle>().MoveToggle(key);
    //                 break;
    //             case KeyBoard.LEFT:
    //                 enemyParent.GetComponent<SetToggle>().MoveToggle(key);
    //                 break;
    //             case KeyBoard.UP:
    //                 enemyParent.GetComponent<SetToggle>().MoveToggle(key);
    //                 break;
    //             case KeyBoard.DOWN:
    //                 enemyParent.GetComponent<SetToggle>().MoveToggle(key);
    //                 break;
    //             case KeyBoard.Z:
    //                 var localToggle = __toggle.GetComponent<Toggle>();
    //                 var enemy = localToggle.GetToggleCurrent();
    //                 break;
    //         }
    //     }

    //     public void Close()
    //     {
    //         __toggle.SetActive(false);
    //     }

    //     public void Destroy()
    //     {
    //         Destroy(__toggle);
    //     }

    //     public void Open()
    //     {
    //         __toggle.SetActive(true);
    //     }
    // }

    public class Enemy : BattleScreen
    {
        private List<GameObject> __enemiesGameObj;
        private List<LocalEnemy> __localEnemies;

        public override void SetUp(BattleHandleData handleData)
        {
            if(handleData.partyEnemy == null)
                throw new SetUpException("partyEnemy in BattleHandleData doesn't set up");

            PartyEnemy party = handleData.partyEnemy;
            __enemiesGameObj = party.enemiesObj;
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
                var enemy = localToggle.GetToggleCurrent();
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
    }
}

