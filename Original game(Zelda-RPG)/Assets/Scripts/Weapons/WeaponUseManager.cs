using UnityEngine;


namespace Samurai
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class WeaponUseManager : MonoBehaviour
    {
        private GameObject Slime;
        private Vector2 direction;
        private int WeaponDir;
        private new Rigidbody2D rigidbody;
        private GameObject[] WeaponsinScene;

        [Range(0,2)]
        public float WeaponSwingSpeed;

        [Range(0,1)]
        public float WeaponSwingTime;

        public SpriteAnimations WeaponUp;
        public SpriteAnimations WeaponDown;
        public SpriteAnimations WeaponLeft;
        public SpriteAnimations WeaponRight;
        private WeaponManager weaponManager;
        public PlayerData PlayerData;
     
        
        private void Awake()
        {
            Slime = GameObject.FindGameObjectWithTag("Player");
            rigidbody = GetComponent<Rigidbody2D>();
            weaponManager = FindObjectOfType<WeaponManager>();

        }

        private void Start()
        {
            WeaponsinScene = GameObject.FindGameObjectsWithTag("Weapons");
            
            if(PlayerData.PlayerDirection == PlayerDirection.Up)
            {
                SetDirection(Vector2.up,WeaponUp);
                direction = Vector2.up;
                Invoke(nameof(RearmWeapon),WeaponSwingTime);
            }else if(PlayerData.PlayerDirection == PlayerDirection.Down)
            {
                SetDirection(Vector2.down,WeaponDown);
                direction = Vector2.down;
                Invoke(nameof(RearmWeapon),WeaponSwingTime);
            }else if(PlayerData.PlayerDirection == PlayerDirection.Left)
            {
                SetDirection(Vector2.left,WeaponLeft);
                direction = Vector2.left;
                Invoke(nameof(RearmWeapon),WeaponSwingTime);
            }else if(PlayerData.PlayerDirection == PlayerDirection.Right)
            {
                direction = Vector2.right;
                SetDirection(Vector2.right,WeaponRight);
                Invoke(nameof(RearmWeapon),WeaponSwingTime);
            }
        }


        private void FixedUpdate()
        {
            Vector2 position = rigidbody.position;
            Vector2 translation = direction * WeaponSwingSpeed * Time.deltaTime;
            rigidbody.MovePosition(position + translation);
        }




       
        
        private void SetDirection(Vector2 newdirection,SpriteAnimations spriteRenderer)
        {
            newdirection = direction;
            WeaponUp.enabled = spriteRenderer == WeaponUp;
            WeaponDown.enabled = spriteRenderer == WeaponDown;
            WeaponLeft.enabled = spriteRenderer == WeaponLeft;
            WeaponRight.enabled = spriteRenderer == WeaponRight;
        }

        private void RearmWeapon()
        {
            foreach(GameObject weapons in WeaponsinScene)
            {
                Destroy(weapons);
                weaponManager.IsUsingaMeleeWeapon = false;
            } 
            
        }

   
    }

}

