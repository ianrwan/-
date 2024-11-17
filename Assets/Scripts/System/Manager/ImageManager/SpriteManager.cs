using System.Collections.Generic;
using UnityEngine;

namespace Megumin.GameSystem
{
    public class SpriteManager : MonoBehaviour
    {
        public static SpriteManager instance{get; private set;}
        
        [Header("存放角色對話圖片")]
        [Tooltip("角色對話的圖片存放位置（僅臉的部分）")]
        [SerializeField]
        private List<SpriteInfo> characterFaces;

        // dictionary 對應關係: 圖片檔名 / 特定圖片資訊 
        private Dictionary<string, SpriteInfo> spriteDictionary = new Dictionary<string, SpriteInfo>();

        private void Awake()
        {
            if(instance != null)
                Debug.LogWarning("It's not allowed to set multiple SpriteManager.");
            instance = this;
            
            MakeSpriteDictionary(characterFaces);
        }

        // input: 圖片的檔名
        // output: 特定圖片資訊
        public SpriteInfo GetSprite(string name)
        {
            Debug.Log("GetSprite IN");
            if(!spriteDictionary.ContainsKey(name))
                return null;

            return spriteDictionary[name];
        }

        // 製作 dictionary 對應關係: 圖片檔名 -> 特定圖片資訊
        // input: 已建構的 List<SpriteInfo>
        private void MakeSpriteDictionary(List<SpriteInfo> spriteInfos)
        {
            foreach(var spriteInfo in spriteInfos)
            {
                spriteDictionary.Add(spriteInfo.Sprite.name, spriteInfo);
            }
        }
    }
}
