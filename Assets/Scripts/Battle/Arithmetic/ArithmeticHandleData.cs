using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
using Megumin.GameSystem;
using Megumin.MeguminException;

namespace Megumin.Battle
{
    [Serializable]
    public class ArithmeticHandleData
    {
        // only for main character temporary
        public static GameObject defenseGameObject;

        public ButtonChoice combatChoice;
        public GameObject current;
        public GameObject target;

        [Header("Tool")]
        public Tool tool;

        [Serializable]
        public class Tool
        {
            private GameSystem.Tool toolID;
            public GameSystem.Tool ToolID
            {
                get => toolID;
            }

            public Tool(GameObject tool)
            {
                if(tool.GetComponent<LocalTool>() == null)
                    throw new NoComponentException("No LocalTool in GameObject, Tool can't be set");

                toolID = tool.GetComponent<LocalTool>().ToolInfo.code;
            }
        }

        public void SetUpTool(GameObject gameObject)
        {
            tool = new Tool(gameObject);
        }
    }

}

