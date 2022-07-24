using UnityEngine;

namespace Samurai
{
    public class ShurikenAdd : MonoBehaviour
    {
        public ItemIndex itemIndex;
        private Throwables ThrowablesManager;
        private ChestManager chestManager;
        private ThrowablesUI throwablesUI;

        public static bool ChesOpened;
        public int NumToAdd;
        public bool ItemAdded;

        public ChestData chestDataManager;


        private void Awake()
        {
            chestManager = GetComponent<ChestManager>();
            throwablesUI = FindObjectOfType<ThrowablesUI>();
            ThrowablesManager = FindObjectOfType<Throwables>();
        }
        

 
        private void SetItemIsAdded()
        {
            itemIndex.ItemID = 0;
            ThrowablesManager.ItemNumber = NumToAdd;
            throwablesUI.ItemsLeft += NumToAdd;
            throwablesUI.ItemReplenished = true;
            ItemAdded = true;
            

        }

    
    }

}

