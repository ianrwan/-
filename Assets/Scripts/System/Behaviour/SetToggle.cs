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

    public void Init()
    {
        toggle = null;
        __posRelative2DArr.Init();
        __componetToggle = null;
        __isToggleMove = false;
    }

    public void SetToggleOnFirstItem()
    {
        if(GetComponent<PosRelative2DArr>() == null)
            throw new ToggleException("PosRelative can't get");
            
        __posRelative2DArr = GetComponent<PosRelative2DArr>();
        __posRelative2DArr.SetUp();
        
        if(__posRelative2DArr == null || prefabToggle == null)
            throw new ToggleException("Toggle isn't set");

        toggle = Instantiate(prefabToggle, __posRelative2DArr.pos2D[0][0].transform);
        __componetToggle = toggle.GetComponent<Toggle>();

        __componetToggle.xPosRelative = 0;
        __componetToggle.yPosRelative = 0;
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
        if(__componetToggle.yPosRelative+1 >= __posRelative2DArr.width)
            return false;
        else
            __componetToggle.yPosRelative += 1;
        return true;
    }

    private bool __MoveLeft()
    {
        if(__componetToggle.yPosRelative-1 < 0)
            return false;
        else
            __componetToggle.yPosRelative -= 1;
        return true;
    }

    private bool __MoveUp()
    {
        if(__componetToggle.xPosRelative-1 < 0)
            return false;
        else
            __componetToggle.xPosRelative -= 1;
        return true;
    }

    private bool __MoveDown()
    {
        if(__componetToggle.xPosRelative+1 >= __posRelative2DArr.height)
            return false;
        else
            __componetToggle.xPosRelative += 1;
        return true;
    }
}
