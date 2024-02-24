using System.Collections.Generic;
using UnityEngine;

namespace Megumin.GameSystem
{
    public class Toggle : MonoBehaviour
    {
        public int xPosRelative;
        public int yPosRelative;
        public new string name;
        public Queue<string> nameRecord{get; private set;}
        private Queue<GameObject> gameObjectsRecord;

        private void Start()
        {
            SetUp();
        }

        public void SetUp()
        {
            var parent = transform.parent.gameObject;
            name = parent.name;
            GetComponent<RectTransform>().anchoredPosition = Vector3.zero; 
        }

        public void EnqueueRecord()
        {
            nameRecord.Enqueue(name);
            gameObjectsRecord.Enqueue(transform.gameObject);
        }

        public void ClearRecord()
        {
            nameRecord.Clear();
            gameObjectsRecord.Clear();
        }

        public void DequeueRecord()
        {
            nameRecord.Dequeue();
            gameObjectsRecord.Dequeue();

            var gameObjButton = gameObjectsRecord.Peek();
            MoveToggle(gameObjButton);
        }

        public void MoveToggle(GameObject gameObject)
        {
            var transform = GetComponent<Transform>();
            transform.SetParent(gameObject.transform);
            SetUp();
        }

        public GameObject GetToggleCurrent()
        {
            return transform.parent.gameObject;
        }
    }
}

