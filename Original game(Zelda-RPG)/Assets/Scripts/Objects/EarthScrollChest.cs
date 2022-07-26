using UnityEngine;

namespace Samurai
{


    public class EarthScrollChest : ChestManager
    {


        private static bool PlayerHasOpenedThisParticularChest;
        public static bool EarthScrollAcquired;
        private bool PlayerIsTouchingThisParticularChest;

        public ItemIndex ItemIndex;

        
        
        private void Awake()
        {
           

        }

        private void Start()
        {
            
            SetBigChestState(ChestClose);
            OpenAnyUsedChest();
        }

        private void Update()
        {
           
            if(Input.GetKey(KeyCode.X) && PlayerIsTouchingThisParticularChest && !PlayerHasOpenedThisParticularChest)
            {
           
                EarthScrollAcquired = true;
                PlayerHasOpenedThisParticularChest = true;
                SetBigChestState(ChestOpen);
         
          

            }

        }

        private void OpenAnyUsedChest()
        {
            if(PlayerHasOpenedThisParticularChest)
            {
                 SetBigChestState(ChestOpen);
            }
        }

        private void SetBigChestState(SpriteAnimations spriteRenderer)
        {
             ChestClose.enabled = spriteRenderer == ChestClose;
             ChestOpen.enabled = spriteRenderer == ChestOpen;
             

        }


        private void OnTriggerStay2D(Collider2D player)
        {
            if(player.gameObject.CompareTag("Player"))
            {
                PlayerIsTouchingThisParticularChest = true;
                ItemIndex.ItemID = 3;
            }

        }

        private void OnTriggerExit2D(Collider2D player)
        {
            PlayerIsTouchingThisParticularChest = false;
        }
   
   


    }
}