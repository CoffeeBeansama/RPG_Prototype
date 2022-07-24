using UnityEngine;
using UnityEngine.UI;

namespace Samurai
{
    [CreateAssetMenu(fileName = "Inventory")]
    public class InventoryStorage : ScriptableObject
    {  
        public Items[] items;
        public bool[] SlotOcccupied;
        public Sprite DefaultSlotSprite;
        
 
    }
    
}

