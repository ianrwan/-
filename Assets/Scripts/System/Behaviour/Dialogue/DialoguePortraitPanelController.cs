using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Megumin.GameSystem.Behaviour
{
    public class DialoguePortraitPanelController : DialoguePanelController
    {
        [Header("圖片變更的區塊")]
        [SerializeField] private GameObject portrait;
        [SerializeField] private ImageSpriteController imageSpriteController;
        private string spriteTag;

        public override void SetData()
        {
            spriteTag = DialogueTagManager.instance.GetTagValue("speaker-portrait");
            if(spriteTag != null)
                imageSpriteController.SetImageSprite(spriteTag);
        }

        protected override void SetController()
        {
            DialogueManager.portraitPanelController = DisplayPanel;
        }
    }
}

