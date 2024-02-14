using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Megumin.DataStructure
{
    public class GameObjectFind
    {
        public List<GameObject> childs;
        public GameObject[] childsArr;
        private int tagAmount;

        public GameObjectFind()
        {
            childs = new List<GameObject>();
            childsArr = new GameObject[100];
        }

        // public List<GameObject> FindDecendantTag(GameObject parent, string tag)
        // {
        //     int childCount = parent.transform.childCount;

        //     if(parent.tag == tag)
        //     {
        //         childs.Add(parent); // GameObject 無法順利加入 list 裡面，加入時會發生錯誤
        //         childsArr[i] = parent;
        //         childs[i] = childsArr[i];
        //         i++;
        //     }

        //     if(childCount == 0)
        //         return null;

        //     for(int i = 0 ; i < childCount ; i++)
        //     {
        //         FindDecendantTag(parent.transform.GetChild(i).gameObject, tag);
        //     }

        //     return childs;
        // }

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
            __FindDecendantTag(parent, tag);
            
            ArrayDealer<GameObject> arrayDealer = new ArrayDealer<GameObject>(childsArr);
            return arrayDealer.TrimArray(tagAmount);
        }
    }
}
