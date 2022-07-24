using UnityEngine;

namespace Samurai
{

    [CreateAssetMenu(fileName = "ItemList")]
    public class ItemList : ScriptableObject
    {
        
        public Items[] itemIndex;
    }
}