using System;
using UnityEngine;

namespace Megumin.GameSystem
{
    public class LocalTool : MonoBehaviour
    {
        [SerializeField]
        private SerializableTool toolInfo;
        public SerializableTool ToolInfo
        {
            get => toolInfo;
        }

        public void SetUp(SerializableTool serializableTool)
        {
            toolInfo = serializableTool;
        }
    }

    [Serializable]
    public class SerializableTool
    {
        public Tool code;
        public TeamChoice use;
        public string name;
        public string explain;
    }
}
