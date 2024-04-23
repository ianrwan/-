using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButtons : MonoBehaviour, ISetUp
{
    [SerializeField] private TitleButton[] titleButtons;
    private List<Serialze> serialze;

    public class Serialze
    {
        public string code;
        public string name;
    }

    public void SetUp()
    {
        serialze = TextAssetsManager.instance.FindObjectsByString<Serialze>("title_buttons");
        if(serialze == null)
            Debug.LogError("serial can't be set");
        SetDataToSingle();
    }

    private void SetDataToSingle()
    {
        int index = 0;
        foreach(var titleButton in titleButtons)
        {
            titleButton.SetUp(serialze[index++]);
        }
    }
}
