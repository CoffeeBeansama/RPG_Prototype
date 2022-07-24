using UnityEngine;
using UnityEngine.UI;

namespace Samurai
{
    public class PlayerInventory : MonoBehaviour
    {
        [Header("Scriptable Objects")]
        public ItemList ItemList;
        public InventoryStorage Inventory;
        public PlayerData playerData;
        private ChestManager chestManager;
        private GameObject[] ItemSlotUI;
        public GameObject InventoryUi;
        private PlayerHP PlayerHPScript;
      

  

        private bool DisplayInventoryUi;
        private bool HideInventoryUi;
        
        
        
     

        private void Start()
        {
            
            PlayerHPScript = FindObjectOfType<PlayerHP>();
            ItemSlotUI = GameObject.FindGameObjectsWithTag("ItemSlots");
            chestManager = FindObjectOfType<ChestManager>();
            DisplayInventoryUi = false;
            HideInventoryUi = true;
            for(int i = 0; i < Inventory.items.Length; i++)
            {
                Inventory.SlotOcccupied[i] = false;
                Inventory.items[i] = null;
                ItemSlotUI[i].GetComponent<Image>().sprite = Inventory.DefaultSlotSprite;
            }

            for(int i = 0; i < ItemList.itemIndex.Length; i++)
            {
                ItemList.itemIndex[i].ItemHave = 0;
            }
            InventoryUi.SetActive(false);
           
            
            
            
        }
        private void Update()
        {

                DisplayingAndHidingUIviaPressedKey();

               
                
           
                
     
        }

        


        private void DisplayingAndHidingUIviaPressedKey()
        {
              if(Input.GetKeyDown(KeyCode.Tab) && HideInventoryUi)
                {
                    HideInventoryUi = false;
                    DisplayInventoryUi = true;
                    if(DisplayInventoryUi)
                    {
                       InventoryUi.SetActive(true);
                    }
                    
                   
                }

                if(InventoryUi.activeInHierarchy)
                {
                    if(Input.GetKeyDown(KeyCode.Escape))
                    {
                        DisplayInventoryUi = false;
                        HideInventoryUi = true;
                         InventoryUi.SetActive(false);


                    }
                    
                }

        }


    }   
    
}

