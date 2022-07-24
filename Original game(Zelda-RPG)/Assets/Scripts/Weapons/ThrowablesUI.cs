using UnityEngine;

namespace Samurai
{
    public class ThrowablesUI : MonoBehaviour
    {
        public int ItemsLeft;
        private int ItemMaxCapacity;
        private int CurrentItemUi;
        public bool ItemReplenished;
        private WeaponManager PlayerManager;
        private ShurikenAdd shurikenAdd;
        private Throwables PlayerThrowables;
        private WeaponManager WeaponManager;
     

    

        private void Awake()
        {
            ItemMaxCapacity = 10;
            PlayerManager = FindObjectOfType<WeaponManager>();
            shurikenAdd = FindObjectOfType<ShurikenAdd>();
            WeaponManager = FindObjectOfType<WeaponManager>();
            PlayerThrowables = FindObjectOfType<Throwables>();
        }
        private void Start()
        {
            ItemsLeft = PlayerData.PlayerItemData;
            ItemReplenished = false;
            LoadCurrentWeaponNumber();
            
        }
     

        private void Update()
        {
            
            PlayerData.PlayerItemData = ItemsLeft;
            if(ItemsLeft >= ItemMaxCapacity)
            {
                ItemsLeft = ItemMaxCapacity;
            }

            if(PlayerThrowables.ItemNumber == ItemMaxCapacity)
            {
                
             ReactivateWeaponUI();
               
            }
        
            if(PlayerManager.RangeState == true)
            {
                WeaponDisposal();
            }
            
         
            
        }

        private void ReactivateWeaponUI()
        {
            ItemsLeft = ItemMaxCapacity;
           
            for(int i = 0; i < ItemMaxCapacity; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true); 
                ItemReplenished = false;
            } 
          
          

        }

        private void WeaponDisposal()
        {
            if(Input.GetKeyDown(KeyCode.Space) && ItemsLeft != 0)
            {
                ItemsLeft--;
                transform.GetChild(ItemsLeft).gameObject.SetActive(false);
               
            }else if(Input.GetKeyDown(KeyCode.Space) && ItemsLeft == 0 ){
                
                ItemsLeft = 0;  
            }

        }

        private void LoadCurrentWeaponNumber()
        {
            int itemsLeft = PlayerData.PlayerItemData;

            for(int i = itemsLeft; i < ItemMaxCapacity; i++)
            {
            transform.GetChild(i).gameObject.SetActive(false);
            }

        }

      

      

        
  
    }   

}

