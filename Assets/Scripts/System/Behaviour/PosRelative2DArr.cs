using System.Collections.Generic;
using UnityEngine;
using Megumin.DataStructure;
using Megumin.MeguminException;

// 使用這個 Behaviour 必須要有 PosRelative2D
public class PosRelative2DArr : MonoBehaviour
{
    public uint height;
    public uint width;
    public GameObject[][] pos2D; // 最後產生二維陣列所在的分布

    private uint[] width1DArray;
    private GameObject[] __pos2DGameObjects;
    private List<PosRelative2D> __pos2Ds;

    public void Init()
    {
        height = 0;
        width = 0;
        pos2D = null;

        width1DArray = null;
        __pos2DGameObjects = null;
        __pos2Ds.Clear();
    }

    public void SetUp()
    {
        __SetPos2DArr();
        __SetHeightAndWidth();
        __SetPos2D();
    }

    private void __SetPos2DArr()
    {
        GameObjectFind gameObjectFind = new GameObjectFind();
        __pos2DGameObjects = gameObjectFind.FindDecendantComponentIsAttached<PosRelative2D>(gameObject);
        __pos2Ds = GameObjectConverter.GetListGameObjComponent<PosRelative2D>(__pos2DGameObjects);

        if(__pos2Ds == null || __pos2DGameObjects == null)
            throw new SetPosException("PosRelative2DArr array isn't set");
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
