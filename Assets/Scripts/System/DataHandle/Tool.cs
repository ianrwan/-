using System;
using UnityEngine;

namespace Megumin.GameSystem
{
    public class LocalTool : MonoBehaviour
    {
        public Tool code;
        public TeamChoice use;
        public new string name;
        public string explain;

        public void SetUp(SerializableTool serializableTool)
        {
            code = serializableTool.code;
            use = serializableTool.use;
            name = serializableTool.name;
            explain = serializableTool.explain;
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
