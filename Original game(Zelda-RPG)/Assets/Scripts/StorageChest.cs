using UnityEngine;

namespace Samurai
{
    public class StorageChest : MonoBehaviour
    {

        public SpriteAnimations StorageChestOpen;
        public SpriteAnimations StorageChestClose;

        private bool PlayerIsTouchingtheChest;
        private bool PlayerisUsingTheChest;

        private void Start()
        {
            SetStorageChestState(StorageChestClose);
        }




        private void Update()
        {
            if(PlayerIsTouchingtheChest)
            {
            
                if(Input.GetKey(KeyCode.X))
                {
                    
                   SetStorageChestState(StorageChestOpen);
                    
                   
                }


                
            }
        }

        private void SetStorageChestState(SpriteAnimations spriteRenderer)
        {
            StorageChestOpen.enabled = spriteRenderer == StorageChestOpen;
            StorageChestClose.enabled = spriteRenderer == StorageChestClose;
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
            SetStorageChestState(StorageChestClose);
        }
    
    }

}


