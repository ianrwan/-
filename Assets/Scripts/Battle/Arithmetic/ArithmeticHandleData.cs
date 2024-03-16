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
        public ButtonChoice combatChoice;
        public GameObject character;
        public GameObject enemy;
        public Tool tool;

        public class Tool
        {
            public GameObject tool;
            public LocalTool localTool;
            public Tool(GameObject tool)
            {
                if(tool.GetComponent<LocalTool>() == null)
                    throw new NoComponentException("No LocalTool in GameObject, Tool can't be set");

                localTool = tool.GetComponent<LocalTool>();
            }
        }

        public void SetUpTool(GameObject gameObject)
        {
            tool = new Tool(gameObject);
        }
    }

}

