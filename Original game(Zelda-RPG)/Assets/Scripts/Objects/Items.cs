using UnityEngine;

namespace Samurai
{

    [CreateAssetMenu(fileName = "Item")]
    public class Items : ScriptableObject
    {
        [Header("Item Properties")]
        public string ItemName;
        public int ItemHave;
        public int NumtoAdd;
        public int MaxItemCapacity;
        public int HealthRestore;
        public int PlayerMaxHPAdd;
        public int ManaRestore;
        public Sprite ItemSprite;
        public bool Droppable;


        [Header ("Shruriken Only")]
        public int ShurikenOnHand;
        public int ShurikenToAdd;
     
    
    }
}