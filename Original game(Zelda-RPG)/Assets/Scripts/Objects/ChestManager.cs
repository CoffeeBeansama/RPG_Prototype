using UnityEngine;
using UnityEngine.UI;

namespace Samurai
{
    public class ChestManager : MonoBehaviour
    {   
        
        public int ChestID;
        public int ItemID; // This Is based on Index on ItemList
        public SpriteAnimations ChestClose;
        public SpriteAnimations ChestOpen;
        private ThrowablesUI ShurikenUi;
        private Throwables PlayerThrowables;
        private ThrowablesUI PlayerShrurikenUi;

   
        
        public InventoryStorage Inventory;
        public ItemList ItemList;
        public ChestData chestData;
        private GameObject[] ItemUi;
        public GameObject playerhand;
        public  bool PlayerIsTouchingtheChest;
        public static bool PlayerhasAcquiredAnItem;
   
    

        private void Awake()
        {
           
            PlayerThrowables = FindObjectOfType<Throwables>();
            PlayerShrurikenUi = FindObjectOfType<ThrowablesUI>();
            ShurikenUi = FindObjectOfType<ThrowablesUI>();
            ItemUi = GameObject.FindGameObjectsWithTag("ItemSlots");

        
        }

        private void Start()
        {
        
            SetChestState(ChestClose);
            if(chestData.IsOpened[ChestID] == true)
            {
                 SetChestState(ChestOpen);
            }
   
        }


      
        
        private void Update()
        {
            if(PlayerIsTouchingtheChest)
            {
                
                if(Input.GetKeyDown(KeyCode.X) && chestData.IsOpened[ChestID] == false )
                { 

                    SetIndividualChestState();
                    chestData.IsOpened[ChestID] = true;
                    SoundManager.instance.PlaySound(chestData.GoldChestItemAcquired);
                    
                       
                }
                      
                    

                


           
            }


                

            
          

      

          
           
          

           

        }
        
        public void SetChestState(SpriteAnimations spriteRenderer)
        {
             ChestClose.enabled = spriteRenderer == ChestClose;
             ChestOpen.enabled = spriteRenderer == ChestOpen;

        }


        private void SetIndividualChestState()
        {     
        
            for(int i = 0; i < Inventory.items.Length; i++)
            {      
             
                if(Inventory.SlotOcccupied[i] == false)
                {
                        
                    PlayerhasAcquiredAnItem = true; 
                    SetChestState(ChestOpen);
                    ItemUi[i].transform.GetChild(0).GetComponentInChildren<Image>().sprite = ItemList.itemIndex[ItemID].ItemSprite;
                    playerhand.GetComponent<SpriteRenderer>().sprite = ItemList.itemIndex[ItemID].ItemSprite;
                    Inventory.items[i] = ItemList.itemIndex[ItemID];
                    Inventory.items[i].ItemHave += Inventory.items[i].NumtoAdd;
                    PlayerThrowables.ItemNumber = Inventory.items[i].ShurikenToAdd;
                    Inventory.SlotOcccupied[i] = true;
                    break;
                }

                if(Inventory.items[i].ItemHave >= Inventory.items[i].MaxItemCapacity)
                {
                    Inventory.items[i].ItemHave = Inventory.items[i].MaxItemCapacity;
                }
                   

                  
                
                
                 
                    
            }


            


           
        }

        

     


        private void OnTriggerStay2D(Collider2D player)
        {
            if(player.gameObject.CompareTag("Player"))
            {
                PlayerIsTouchingtheChest = true;
            
            }
        }

        private void OnTriggerExit2D(Collider2D player)
        {
            PlayerIsTouchingtheChest = false;
        }


       

      
       


    
    }

}

