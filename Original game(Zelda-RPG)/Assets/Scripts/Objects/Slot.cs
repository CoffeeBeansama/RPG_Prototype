using UnityEngine;
using UnityEngine.UI;

namespace Samurai
{
    public class Slot : MonoBehaviour
    {
        public Sprite DefaultSprite;
        public InventoryStorage Inventorystorage;

        public int SlotIndex;

        private PlayerHP PlayerHPScript;

        private void Awake()
        {
            PlayerHPScript = FindObjectOfType<PlayerHP>();
        }

        public void UseAndRemoveItem()
        {
            
            if(Inventorystorage.items[SlotIndex].Droppable == true)
            {

               
                   
                
                
                PlayerHPScript.Playerhp += Inventorystorage.items[SlotIndex].HealthRestore;
                PlayerHPScript.PlayerMaxHP += Inventorystorage.items[SlotIndex].PlayerMaxHPAdd;
                Inventorystorage.SlotOcccupied[SlotIndex] = false;
                Inventorystorage.items[SlotIndex] = null;
                gameObject.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;  
            }
           



        }
    }
}