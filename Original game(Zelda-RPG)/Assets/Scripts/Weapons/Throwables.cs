using UnityEngine;


namespace Samurai
{
    public class Throwables : MonoBehaviour
    {

        private GameObject WeaponUi;
        public Items itemsData;
        public PlayerData playerData;
        private WeaponManager PlayerManager;
        public int ItemNumber;
        public int MaxItemCapacity;

        private void Awake()
        {
            PlayerManager = GetComponent<WeaponManager>();
            WeaponUi = GameObject.FindGameObjectWithTag("WeaponUI");
        }

        private void Start()
        {
            ItemNumber = PlayerData.PlayerItemData;

        }


        protected void Update()
        {
            InventoryisEmpty();
            PlayerData.PlayerItemData = ItemNumber;
           
           itemsData.ShurikenOnHand = ItemNumber;
           if(PlayerManager.RangeState == true && ItemNumber != 0)
           {
             if(Input.GetKeyDown(KeyCode.Space))
             {
                
                ItemNumber--;
                itemsData.ShurikenOnHand--;
                WeaponUi.SetActive(true);
             }

             if(ItemNumber >= MaxItemCapacity)
             {

                ItemNumber = MaxItemCapacity;

             }

           }

           

          
        }

        public bool InventoryisEmpty()
        {
           return ItemNumber <= 0;
        }

        

     

        




    }

}


