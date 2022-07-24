using UnityEngine;

namespace Samurai
{
    public class MovementManager : MonoBehaviour
    {
        
     
        private new Rigidbody2D rigidbody2D;
        [SerializeField] public float speed = 5f;
        private Vector2 direction = Vector2.down;
        private WeaponManager weaponManager;
        private GameObject[] ItemChests;

        public SpriteAnimations spriteRendererUp;
        public SpriteAnimations spriteRendererDown;
        public SpriteAnimations spriteRendererLeft;
        public SpriteAnimations spriteRendererRight;
        private SpriteAnimations ActiveSpriteRenderer;
        public SpriteAnimations WeaponUseUp;
        public SpriteAnimations WeaponUseDown;
        public SpriteAnimations WeaponUseLeft;
        public SpriteAnimations WeaponUseRight;
        public SpriteAnimations ChestOpened;
        private GameObject[] Enemy;
        public PlayerData PlayerData;
        private bool AllowedToMove;
        private bool ItemChestAction;
        

        private void Awake()
        {
            Enemy = GameObject.FindGameObjectsWithTag("Enemies");
            rigidbody2D = GetComponent<Rigidbody2D>();
            ActiveSpriteRenderer = spriteRendererDown;
            weaponManager = GetComponent<WeaponManager>();
            ItemChests = GameObject.FindGameObjectsWithTag("ItemChests");
        }

        private void Start()
        {
            SetDefaultSprites();
            transform.position = PlayerData.PlayerInitialPosition;
            PlayerData.PlayerDirection = PlayerDirection.Down;
        }
        private void Update()
        {

            if(AllowedToMove)
            {
               
                if(Input.GetKey(KeyCode.UpArrow))
                {
                PlayerData.PlayerDirection = PlayerDirection.Up;
                SetDirection(Vector2.up,spriteRendererUp);

                }else if(Input.GetKey(KeyCode.DownArrow))
                {
                 PlayerData.PlayerDirection = PlayerDirection.Down;
                 SetDirection(Vector2.down,spriteRendererDown);
                }else if(Input.GetKey(KeyCode.LeftArrow))
                {
                PlayerData.PlayerDirection = PlayerDirection.Left;
                SetDirection(Vector2.left,spriteRendererLeft);

                }else if(Input.GetKey(KeyCode.RightArrow))
                {
                PlayerData.PlayerDirection = PlayerDirection.Right;
                SetDirection(Vector2.right,spriteRendererRight);
                }else
                {
                SetDirection(Vector2.zero,ActiveSpriteRenderer);
                }

            }


            if(Input.GetKeyDown(KeyCode.Space))
            {
               AllowedToMove = false;
               SetWeaponActionSprites();
                if(PlayerData.PlayerDirection == PlayerDirection.Up)
                {
                    
                     SetWeaponDirection(WeaponUseUp);
                    

                }else if(PlayerData.PlayerDirection == PlayerDirection.Down){

                     SetWeaponDirection(WeaponUseDown);
                     

                }else if(PlayerData.PlayerDirection == PlayerDirection.Left){

                     SetWeaponDirection(WeaponUseLeft);
                    

                }else if(PlayerData.PlayerDirection == PlayerDirection.Right){

                     SetWeaponDirection(WeaponUseRight);


                }
                Invoke(nameof(SetDefaultSprites),0.30f);
             }

            
            
                if(ChestManager.PlayerhasAcquiredAnItem == true)
                {
                 ItemChestAction = true;
                 
                 AllowedToMove = false;
                 SetItemAquireSprites();
                 ItemAqcuireAnimations(ChestOpened);
                 Invoke(nameof(SetDefaultSprites),1f);
                 ChestManager.PlayerhasAcquiredAnItem = false;
                 
                }
             
            
            
           

            
        }


        private void FixedUpdate()
        {
            if(!weaponManager.IsUsingaMeleeWeapon && !ItemChestAction)
            {
            AllowedToMove = true;
            
            Vector2 position = rigidbody2D.position;
            Vector2 translation = direction * speed * Time.deltaTime;
            rigidbody2D.MovePosition(position + translation);
            }
            else{
            AllowedToMove = false;
            }
        
            
        }

        private void SetDirection(Vector2 newDirection, SpriteAnimations spriteRenderer)
        {
             
            direction = newDirection;

            
            spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
            spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
            spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;
            spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;
            ActiveSpriteRenderer = spriteRenderer;
            ActiveSpriteRenderer.idle = direction == Vector2.zero;
            

        }

        private void SetWeaponDirection(SpriteAnimations spriteAnimations)
        {
            WeaponUseUp.enabled = spriteAnimations == WeaponUseUp;
            WeaponUseDown.enabled = spriteAnimations == WeaponUseDown;
            WeaponUseLeft.enabled = spriteAnimations == WeaponUseLeft;
            WeaponUseRight.enabled = spriteAnimations == WeaponUseRight;

        }

        private void ItemAqcuireAnimations(SpriteAnimations spriteAnimations)
        {
            ChestOpened.enabled = spriteAnimations == ChestOpened;
        }
        
        private void SetDefaultSprites()
        {
            ItemChestAction = false;
            for(int i = 0; i < 4; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            for(int i = 4; i < 9; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        private void SetWeaponActionSprites()
        {
            for(int i = 0; i < 4; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            for(int i = 4; i < 8; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }

        }

        private void SetItemAquireSprites()
        {
            for(int i = 0; i < 8; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
             transform.GetChild(8).gameObject.SetActive(true);


        }

        private bool DialogueBoxisActive()
        {
            if(Enemy != null)
            { 
                foreach(GameObject enemy in Enemy)
                {
                    if(enemy.GetComponent<EnemyInteract>().DialogueBoxisActive == true)
                    {
                        return true;
                    }
                }
                
                
            }
            
                return false;
            
        }
        private void OnTriggerStay2D(Collider2D enemies)
        {
           
            if(enemies.gameObject.tag == "Interactables")
            {
                if(Input.GetKey(KeyCode.X))
                {

                    enemies.gameObject.GetComponent<EnemyInteract>().ActivateDialogue();
                }
            }

        }

        private void OnTriggerExit2D(Collider2D enemies)
        {
            Enemy = null;
        }


  
    

    


    }

    
     

}
