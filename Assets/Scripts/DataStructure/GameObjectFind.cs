using System;
using System.Collections;
using System.Collections.Generic;
using Megumin.GameSystem;
using UnityEngine;

namespace Megumin.DataStructure
{
    public class GameObjectFind
    {
        public List<GameObject> childs;
        public GameObject[] childsArr;
        private int tagAmount;
        public string[] strings;

        public GameObjectFind()
        {
            __Reset();
        }

        private void __Reset()
        {
            childsArr = new GameObject[100];
            tagAmount = 0;
        }

        private GameObject[] __FindDecendantTag(GameObject parent, string tag)
        {
            int childCount = parent.transform.childCount;

            if(parent.tag == tag)
            {
                childsArr[tagAmount++] = parent;
            }

            if(childCount == 0)
                return null;

            for(int i = 0 ; i < childCount ; i++)
            {
                __FindDecendantTag(parent.transform.GetChild(i).gameObject, tag);
            }
            
            return childsArr;
        }

        public GameObject[] FindDecendantTag(GameObject parent, string tag)
        {
            __Reset();
            __FindDecendantTag(parent, tag);
            
            ArrayDealer<GameObject> arrayDealer = new ArrayDealer<GameObject>(childsArr);
            return arrayDealer.TrimArray(tagAmount);
        }

        private void __FindDecendantComponentIsAttached<T>(GameObject parent)
        {
            int childCount = parent.transform.childCount;

            if(parent.GetComponent<T>() != null)
            {
                childsArr[tagAmount++] = parent;
            }

            if(childCount == 0)
                return;

            for(int i = 0 ; i < childCount ; i++)
            {
                __FindDecendantComponentIsAttached<T>(parent.transform.GetChild(i).gameObject);
            }

            return;
        }

        public GameObject[] FindDecendantComponentIsAttached<T>(GameObject parent)
        {
            __Reset();
            __FindDecendantComponentIsAttached<T>(parent);

            ArrayDealer<GameObject> arrayDealer = new ArrayDealer<GameObject>(childsArr);
            return arrayDealer.TrimArray(tagAmount);
        }
    }
}
