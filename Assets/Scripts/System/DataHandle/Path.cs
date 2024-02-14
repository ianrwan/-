using UnityEngine;

namespace Megumin.GameSystem
{
    public static class Path
    {
        public static string pathCharacter = Application.dataPath+@"\Storage\CharacterInfo\main_character.json";
        public static string pathParty = Application.dataPath+@"\Storage\CharacterInfo\party.json";
        public static string pathButton = Application.dataPath+@"\Storage\Setting\button.json";
        public static string pathEnemy = Application.dataPath+@"\Storage\Enemy\enemy.json";

        public static class BattleSystem
        {
            public static string battleCharacterVector = Application.dataPath+@"\Storage\Setting\battleCharacterVector.json";
            public static string battleChoiceVector = Application.dataPath+@"\Storage\Setting\battleChoiceVector.json";
        }
    }
}
