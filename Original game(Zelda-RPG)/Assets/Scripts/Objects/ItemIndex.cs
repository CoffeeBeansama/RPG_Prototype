using UnityEngine;

namespace Samurai
{
    [CreateAssetMenu(fileName = "ItemIndex")]
    public class ItemIndex : ScriptableObject
    {
        public int ItemID;
        public Sprite[] ItemSprite;
    
    }

}

