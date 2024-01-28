using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class OptionManagerEnemy : OptionManager
{
    private bool isChoosing = false;

    public new static OptionManagerEnemy instance{get; private set;}

    private void Awake()
    {
        instance = this;
    }

    public new void Start()
    {
        base.button = null;
        base.selector = null;
        base.buttonIndex = 0;

        base.FindSelector("Enemy");
    }

    public override IEnumerator MoveSelector(int command = 0)
    {
        if(isChoosing == true)
            yield break;

        isChoosing = true;

        if(command == 0)
            buttonIndex = (buttonIndex-1 < 0) ? button.transform.parent.childCount-1 : buttonIndex-1; 
        else
            buttonIndex = (buttonIndex+1 >= button.transform.parent.childCount) ? 0 : buttonIndex+1; 
        var currentButton = button.transform.parent.GetChild(buttonIndex);
        
        selector.transform.SetParent(currentButton);
        button = currentButton.gameObject;
        SetSelectorPosition();

        yield return new WaitForSeconds(0.2f);
        isChoosing = false;
    }

    private void SetSelectorPosition()
    {
        var parentPos = selector.transform.parent.position;
        Debug.Log(parentPos+","+selector.transform.position);
        selector.transform.position = new Vector3(parentPos.x, parentPos.y+1.0f, selector.transform.position.z);
    }
}
