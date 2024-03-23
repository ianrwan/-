using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Megumin.MeguminException;
using Megumin.GameSystem;

// 使用這個 Behaviour 必須要有 PosRelative2DArr 且必須要放在一起
public class SetToggle : MonoBehaviour
{
    public GameObject prefabToggle;
    public GameObject toggle;
    private PosRelative2DArr __posRelative2DArr;
    private Toggle __componetToggle;
    private bool __isToggleMove = false;

    [Tooltip( "是否強制將橫向變換時設為 x = 0")]
    public bool isHorizentalSetFirst = false;
    [Tooltip( "是否強制將縱向變換時設為 y = 0")]
    public bool isVerticalSetFirst = false; 

    public void Init()
    {
        toggle = null;
        __posRelative2DArr.Init();
        __componetToggle = null;
        __isToggleMove = false;
    }

    public void SetToggleOnFirstItem()
    {
        SetToggleOnFirstItem(0, 0);
    }

    public void SetToggleOnFirstItem(GameObject[] gameObjects)
    {
        __posRelative2DArr = GetComponent<PosRelative2DArr>();
        __posRelative2DArr.SetUp(gameObjects);
        SetUpToggle();
    }

    public void SetToggleOnFirstItem(int x, int y)
    {
        if(GetComponent<PosRelative2DArr>() == null)
            throw new ToggleException("PosRelative can't get");

        __posRelative2DArr = GetComponent<PosRelative2DArr>();
        __posRelative2DArr.SetUp();
        
        SetUpToggle(x, y);
    }

    // Exclude 代表將已經處理好的 GameObjcet 傳進來 (傳入要直接 set toggle 的 gameobject)
    public void SetToggleOnFirstItemExclude(GameObject[] gameObjects)
    {
       SetToggleOnFirstItemExclude(gameObjects, 0, 0);
    }

    public void SetToggleOnFirstItemExclude(GameObject[] gameObjects, int x, int y)
    {
        __posRelative2DArr = GetComponent<PosRelative2DArr>();
        __posRelative2DArr.SetUpExclude(gameObjects);
        SetUpToggle(x, y);
    }

    private void SetUpToggle()
    {
        SetUpToggle(0 , 0);
    }

    private void SetUpToggle(int x, int y)
    {
        if(__posRelative2DArr == null || prefabToggle == null)
            throw new ToggleException("Toggle isn't set");

        toggle = Instantiate(prefabToggle, __posRelative2DArr.pos2D[x][y].transform);
        __componetToggle = toggle.GetComponent<Toggle>();

        SetToggleRelative(x, y);
    }

    private void SetToggleRelative(int x, int y)
    {
        __componetToggle.xPosRelative = x;
        __componetToggle.yPosRelative = y;
    }

    public void MoveToggle(KeyBoard key)
    {
        switch(key)
        {
            case KeyBoard.RIGHT:
                __isToggleMove = __MoveRight();
                break;
            case KeyBoard.LEFT:
                __isToggleMove = __MoveLeft();
                break;
            case KeyBoard.UP:
                __isToggleMove = __MoveUp();
                break;
            case KeyBoard.DOWN:
                __isToggleMove = __MoveDown();
                break;
        }

        if(__isToggleMove)
        {
            __componetToggle.MoveToggle(__posRelative2DArr.pos2D[__componetToggle.xPosRelative][__componetToggle.yPosRelative]);
            __isToggleMove = false;
        }
    }

    private bool __MoveRight()
    {
        if(isHorizentalSetFirst)
            __componetToggle.xPosRelative = 0;

        if(__componetToggle.yPosRelative+1 >= __posRelative2DArr.Width1DArray[__componetToggle.xPosRelative])
            return false;
        else
            __componetToggle.yPosRelative += 1;
        return true;
    }

    private bool __MoveLeft()
    {
        if(isHorizentalSetFirst)
            __componetToggle.xPosRelative = 0;

        if(__componetToggle.yPosRelative-1 < 0)
            return false;
        else
            __componetToggle.yPosRelative -= 1;
        return true;
    }

    private bool __MoveUp()
    {
        if(isVerticalSetFirst)
            __componetToggle.yPosRelative = 0;

        if(__componetToggle.xPosRelative-1 < 0)
            return false;
        else
            __componetToggle.xPosRelative -= 1;
        return true;
    }

    private bool __MoveDown()
    {
        if(isVerticalSetFirst)
            __componetToggle.yPosRelative = 0;

        if(__componetToggle.xPosRelative+1 >= __posRelative2DArr.Height1DArray[__componetToggle.yPosRelative])
            return false;
        else
            __componetToggle.xPosRelative += 1;
        return true;
    }
}
