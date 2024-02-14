using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Megumin.GameSystem;
using UnityEngine;
using UnityEngine.UI;

public class StartSetScreen : MonoBehaviour
{
    public Text[] textCharacters;
    public Text[] textEnemies;

    public void SetCharacter(Party party)
    {
        int i = 0;
        foreach(var character in party.characters)
        {
            textCharacters[i].text = character.job+'\n'+character.hp;
            i++;
        }

        SetRemainNotActive(textCharacters, i);
    }

    public void SetEnemy(PartyEnemy party)
    {
        int i = 0;
        foreach(var enemy in party.enemies)
        {
            textEnemies[i].text = enemy.name+'\n'+enemy.hp;
            i++;
        }

        SetRemainNotActive(textEnemies, i);
    }

    private void SetRemainNotActive(Text[] texts, int i)
    {
        for( ; i < texts.Count(); i++)
        {
            texts[i].gameObject.SetActive(false);
        }
    }
}
