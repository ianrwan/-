using System.Collections;
using System.Collections.Generic;
using Megumin.Battle;
using Megumin.GameSystem;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField] BattleSystem battleSystem;
    private Text hpText;

    private void Awake()
    {
        hpText = GetComponent<Text>();       
    }

    private void Update()
    {
        if(battleSystem.battleHandleData.party != null)
        {
            string currentHP = battleSystem.battleHandleData.party.GetPartyGameObjets()[0].GetComponent<LocalMainCharacter>().HP+"";
            hpText.text = "HP "+currentHP+" / 10";
        }
            
    }
}
