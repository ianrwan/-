using UnityEngine;
using UnityEngine.UI;

// 必須要有 "Image" 的 Component 才可以使用
// 必須要有 "SpriteManager" 才可以使用
namespace Megumin.GameSystem.Behaviour
{
    public class ImageSpriteController : MonoBehaviour
    {
        [Header("Component Image")]
        [SerializeField] private Image image;

        [Header("圖片檔案名稱")]
        [Tooltip("Null is allowed.")]
        [SerializeField] private new string name = null;

        private SpriteInfo spriteInfo;

        private void Awake()
        {
            if(image == null)
            {
                image = GetComponent<Image>();
                if(image is null) Debug.LogError("No Image component in the inspector, ImageSpriteController should be used when existing Image.");
            }
        }

        private void Start()
        {
            if(SpriteManager.instance == null)
                Debug.LogError("No SpriteManager in any GameObjects, ImageSpriteController should be used when existing SpriteManager.");

            if(name != null && name != "")
                SetImageSprite(name);
        }

        // 將 Image 的 Sprite 從 SpriteManager 取出並且設定
        // input: sprite 的檔案名稱 
        public void SetImageSprite(string spriteName)
        {
            spriteInfo = SpriteManager.instance.GetSprite(spriteName);
            if(spriteInfo == null)
            {
                Debug.LogWarning($"spriteName isn't found, spriteName:{spriteName}");
                return;
            };

            name = spriteName;
            image.sprite = spriteInfo.Sprite;
        }

        // 將 Image 的 Sprite 清除
        public void ClearImageSprite()
        {
            image.sprite = null;
        }
    }

}
