using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Megumin.Battle
{
    public class DeadArithmetic : MonoBehaviour
    {
        public static DeadArithmetic instance{get; private set;}

        [Tooltip("Set the battleArithmetic on.")]
        [SerializeField] private BattleArithmetic battleArithmetic;

        private IEntityDataGet targetGet;

        public bool isDead{get; private set;}

        private void Awake()
        {
            instance = this;

            isDead = false;
        }

        public void On()
        {
            if(battleArithmetic.handleData.target == null)
                return;
            targetGet = battleArithmetic.handleData.target.GetComponent<IEntityDataGet>();
            CheckDead();
        }

        private void CheckDead()
        {
            if(targetGet.GetHealth() != 0)
                return;

            isDead = true;
            ArithmeticAnimation.instance.SetUp(targetGet.GetGameObject());
            ArithmeticAnimation.instance.Dead(true);
            
            StartCoroutine(Wait());
        }

        private IEnumerator Wait()
        {
            yield return new WaitForSeconds(3);
            SceneGlobal.goScene = "Title";
            SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
        }
    }
}

