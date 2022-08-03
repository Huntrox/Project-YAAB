using UnityEngine;

namespace HuntroxGames.Utils
{
    public class SpriteViewAttribute : PropertyAttribute
    {

        public float size = 64;
        public SpriteViewAttribute() => size = 64;

        public SpriteViewAttribute(float size)
        {
            this.size = size;
        }

    }
}
