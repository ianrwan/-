using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LengthAndHeightCalculator : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

    [SerializeField] private GameObject panel;
    private GridLayoutGroup gridLayoutGroup;
    private int objectAmount; // the amount inside panel

    public float canvasHeight;
    public float panelHeight;
    public float panelToButtomHeight;

    // set up will start after the objects inside panel complete, or it will get error
    public void SetUp()
    {
        if(GetComponent<GridLayoutGroup>() == null)
            Debug.LogError("This component should need GridLayoutGroup");

        gridLayoutGroup = panel.GetComponent<GridLayoutGroup>();
        objectAmount = panel.transform.childCount;

        CalculateHeight();
        SetTop();
    }

    public void CalculateHeight()
    {
        panelHeight = gridLayoutGroup.padding.top + gridLayoutGroup.padding.bottom 
            + gridLayoutGroup.cellSize.y*objectAmount + gridLayoutGroup.spacing.y*(objectAmount-1);

        canvasHeight = canvas.GetComponent<RectTransform>().rect.height;
        panelToButtomHeight = panel.GetComponent<RectTransform>().offsetMin.y;
    }

    public void SetTop()
    {
        var rectTransform = panel.GetComponent<RectTransform>();
        rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, 
            -Mathf.Floor(canvasHeight-panelHeight-panelToButtomHeight));
    }
}
