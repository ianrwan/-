using UnityEngine;
using System;

namespace Megumin.GameSystem
{
    [Serializable]
    public class SpriteInfo
    {
        [SerializeField]
        private Sprite sprite;
        public Sprite Sprite
        {
            get => sprite;
        }
    }
}

