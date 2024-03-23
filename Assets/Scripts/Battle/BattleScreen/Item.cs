using System;
using UnityEngine;
using UnityEngine.UI;
using Megumin.DataStructure;
using Megumin.GameSystem;
using System.Collections;


namespace Megumin.Battle
{
    public class Item : BattleScreen, IGetUpperData<GameObject>, IGetUpperData<TeamChoice>
    {
        public GameObject choicePrefab;
        public GameObject choiceParent;
        private SerializableTool[][] serializableTools;

        private int maxPage;
        private int currentPage;
        public GameObject showExplain;

        private GameObject tool; // 傳回 tool 目前的資料
        private TeamChoice teamChoice;

        public override void SetUp(BattleHandleData handleData)
        {
            SetToolFromCharacter(handleData);
            _parent = Instantiate(prefab, root.transform);

            GameObjectFind gameObjectFind = new GameObjectFind();
            choiceParent = gameObjectFind.FindDecendantTag(_parent, "Selector")[0];
            SetLocalTool(currentPage);
            SetGameObjects();
            SetUp();
            Cover();
        }

        private void SetToolFromCharacter(BattleHandleData handleData)
        {
            var characters = GameObject.FindGameObjectsWithTag("Characters");
            var tools = characters[0].GetComponent<LocalMainCharacter>().tool; // 暫時放置角色

            int arraySize = tools.Length/5+1;
            serializableTools = new SerializableTool[arraySize][];

            for(int i = 0 ; i < arraySize ; i++)
            {
                if(i+1 != arraySize && tools.Length%5 != 0)
                    serializableTools[i] = new SerializableTool[5];
                else
                    serializableTools[i] = new SerializableTool[tools.Length%5];
            }

            int counter = 0;
            for(int i = 0 ; i < arraySize ; i++)
            {
                for(int j = 0 ; j < serializableTools[i].Length ; j++)
                {
                    serializableTools[i][j] = handleData.dictionarySet.toolDicitonary[tools[counter++]];
                }
            }

            maxPage = arraySize;
            currentPage = 1;
        }

        private void SetLocalTool(int currentPage)
        {
            for(int i = 0 ; i < serializableTools[currentPage-1].Length ; i++)
            {
                var choice = Instantiate(choicePrefab, choiceParent.transform);
                var localTool = choice.GetComponent<LocalTool>();
                localTool.SetUp(serializableTools[currentPage-1][i]);
                
                var pos2D = choice.GetComponent<PosRelative2D>();
                pos2D.x = Convert.ToUInt32(i);
            }
        }

        private void SetGameObjects()
        {
            GameObjectFind gameObjectFind = new GameObjectFind();
            _gameObjects = gameObjectFind.FindDecendantComponentIsAttached<PosRelative2D>(_parent);
        }

        public override void ShowText()
        {
            for(int i = 0 ; i < _gameObjects.Length ; i++)
            {
                var localTool = _gameObjects[i].GetComponent<LocalTool>();
                var textGameObj = _gameObjects[i].transform.GetChild(0);

                var text = textGameObj.GetComponent<Text>();
                text.text = localTool.name;
            }
        }

        public override void UserInput(KeyBoard key)
        {
            _LocalDatasExceptionHandle();

            switch(key)
            {
                case KeyBoard.RIGHT:
                    RightClick();
                    break;
                case KeyBoard.LEFT:
                    LeftClick();
                    break;
                case KeyBoard.UP:
                    _parent.GetComponent<SetToggle>().MoveToggle(key);
                    Cover();
                    break;
                case KeyBoard.DOWN:
                    _parent.GetComponent<SetToggle>().MoveToggle(key);
                    Cover();
                    break;
                case KeyBoard.Z:
                    _zPress?.Invoke();
                    break;
                case KeyBoard.X:
                    _xPress?.Invoke();
                    break;
            }
        }

        private void Cover()
        {
            GameObjectFind gameObjectFind = new GameObjectFind();
            var explainPlace = gameObjectFind.FindDecendantTag(_parent, "Selector")[1];
            var text = explainPlace.GetComponent<Text>();
            
            var localToggle = _toggle.GetComponent<GameSystem.Toggle>();
            var gameObj = localToggle.GetToggleCurrent();
            var localTool = gameObj.GetComponent<LocalTool>();

            text.text = localTool.explain;
        }

        private void RightClick()
        {
            if(currentPage+1 > maxPage)
                return;

            currentPage++;
            StartCoroutine(AdjustToolShow());
        }

        private void LeftClick()
        {
            if(currentPage-1 <= 0)
                return;

            currentPage--;
            StartCoroutine(AdjustToolShow());
        }

        private IEnumerator AdjustToolShow()
        {
            foreach(var data in _gameObjects)
                Destroy(data);
            SetLocalTool(currentPage);
            SetGameObjects();
            ShowText();

            _parent.GetComponent<SetToggle>().Init();

            yield return 0;
            _SetUpToggle(0);
        }

        protected override void _LocalDatasExceptionHandle()
        {

        }

        protected override void _SetUpInput()
        {
            _zPress = () =>
            {
                tool = _toggle.GetComponent<GameSystem.Toggle>().GetToggleCurrent();
                var localTool = tool.GetComponent<LocalTool>();
                teamChoice = localTool.use;
                Click click = GetComponent<Click>();
                click.Do();
            };
        }

        GameObject IGetUpperData<GameObject>.GetData()
        {
            return tool;
        }

        TeamChoice IGetUpperData<TeamChoice>.GetData()
        {
            return teamChoice;
        }
    }
}

