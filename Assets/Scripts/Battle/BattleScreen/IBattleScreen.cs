using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Megumin.GameSystem;

public interface IBattleScreen
{
    public void SetUpButton(List<SerealizableButton> list);
    public void ShowButtonText();
    public GameObject[] GetButtonsGameObj();
    public void ButtonDo(KeyBoard num);
    public void Close();
}
