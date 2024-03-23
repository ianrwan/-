using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Megumin.DataStructure;
using Megumin.MeguminException;
using Unity.VisualScripting;

// 使用這個 Behaviour 必須要有 PosRelative2D
public class PosRelative2DArr : MonoBehaviour
{
    public uint height;
    public uint width;
    public GameObject[][] pos2D; // 最後產生二維陣列所在的分布

    [Tooltip("Let Component use the gameobject itself.")]
    public bool isSelf = true; 

    private uint[] width1DArray;
    public uint[] Width1DArray
    {
        get {return (uint[])width1DArray.Clone();}
    }

    private uint[] height1DArray;
    public uint[] Height1DArray
    {
        get {return (uint[])height1DArray.Clone();}
    }
    
    private GameObject[] __pos2DGameObjects;
    private List<PosRelative2D> __pos2Ds;

    public void Init()
    {
        height = 0;
        width = 0;
        pos2D = null;

        width1DArray = null;
        height1DArray = null;
        __pos2DGameObjects = null;
        __pos2Ds.Clear();
    }

    public void SetUp()
    {
        if(isSelf)
            __SetPos2DArr();

        if(__pos2Ds == null || __pos2DGameObjects == null)
            throw new SetPosException("PosRelative2DArr array isn't set");

        __SetHeightAndWidth();
        __SetPos2D();
    }

    public void SetUp(GameObject[] gameObjects)
    {
        __SetPos2DArr(gameObjects);
        SetUp();
    }

    public void SetUp(GameObject gameObject)
    {
        __SetPos2DArr(gameObject);
        SetUp();
    }

    public void SetUpExclude(GameObject[] gameObjects)
    {
        __SetPos2DArrExclude(gameObjects);
        SetUp();
    }

    private void __SetPos2DArr()
    {
        __SetPos2DArr(gameObject);
    }

    private void __SetPos2DArr(GameObject[] gameObjects)
    {
        GameObject[] store = new GameObject[0];

        foreach(var gameObject in gameObjects)
        {
            GameObjectFind gameObjectFind = new GameObjectFind();
            var data = gameObjectFind.FindDecendantComponentIsAttached<PosRelative2D>(gameObject);
            store = store.Concat(data).ToArray();
        }
        __pos2DGameObjects = store;
        __pos2Ds = GameObjectConverter.GetListGameObjComponent<PosRelative2D>(store);
    }

    private void __SetPos2DArrExclude(GameObject[] gameObjects)
    {
        __pos2DGameObjects = gameObjects;
        __pos2Ds = GameObjectConverter.GetListGameObjComponent<PosRelative2D>(gameObjects);
    }

    private void __SetPos2DArr(GameObject gameObject)
    {
        GameObjectFind gameObjectFind = new GameObjectFind();
        __pos2DGameObjects = gameObjectFind.FindDecendantComponentIsAttached<PosRelative2D>(gameObject);
        __pos2Ds = GameObjectConverter.GetListGameObjComponent<PosRelative2D>(__pos2DGameObjects);
    }

    private void __SetHeightAndWidth()
    {
        foreach(var data in __pos2Ds)
        {
            if(data.x > height)
                height = data.x;
            
            if(data.y > width)
                width = data.y;
        }

        height += 1;
        width += 1;

        width1DArray = new uint[height];

        foreach(var data in __pos2Ds)
        {
            if(data.y+1 > width1DArray[data.x])
                width1DArray[data.x] = data.y+1;
        }

        height1DArray = new uint[width];

        foreach(var data in __pos2Ds)
        {
            if(data.x+1 > height1DArray[data.y])
                height1DArray[data.y] = data.x+1;   
        }
    }

    private void __SetPos2D()
    {
        pos2D = new GameObject[height][];
        
        for(int i = 0 ; i < height ; i++)
        {
            pos2D[i] = new GameObject[width1DArray[i]];
        }

        foreach(var gameObject in __pos2DGameObjects)
        {
            var localPos2D = gameObject.GetComponent<PosRelative2D>();
            pos2D[localPos2D.x][localPos2D.y] = gameObject;
        }
    }
}
