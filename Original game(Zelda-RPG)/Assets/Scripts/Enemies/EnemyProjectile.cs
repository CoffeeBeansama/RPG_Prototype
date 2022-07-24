using UnityEngine;

namespace Samurai
{
    public class EnemyProjectile : MonoBehaviour
    {
        [Range(0f,5f)]
        private GameObject Player;
        public int Damage;
        public float ProjectileSpeed;
        public SpriteAnimations Up;
        public SpriteAnimations Down;
        public SpriteAnimations Left;
        public SpriteAnimations Right;
        public bool OneInstanceExists = true;

        private new Rigidbody2D rigidbody;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            Player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {
            ChasePlayer();
        }

        private void ChasePlayer()
        {
            OneInstanceExists = true;
            Vector3 NewPosition = Vector3.MoveTowards(transform.position,Player.transform.position, ProjectileSpeed * Time.deltaTime);
            SetProjectileSpriteDirection(NewPosition - transform.position); 
            rigidbody.MovePosition(NewPosition);

        }


         private void SetProjectileSprite(SpriteAnimations spriteRenderer)
        {
           
            Up.enabled = spriteRenderer == Up;
            Down.enabled = spriteRenderer == Down;
            Left.enabled = spriteRenderer == Left;
            Right.enabled = spriteRenderer == Right;
        
            

        }
        private void SetProjectileSpriteDirection(Vector2 setDirection)
        {
             if(Mathf.Abs(setDirection.x) > Mathf.Abs(setDirection.y))
            {
                if(setDirection.x > 0){

                  SetProjectileSprite(Right);
                  

                }else if(setDirection.x < 0){

                   SetProjectileSprite(Left);
                }

            }else if(Mathf.Abs(setDirection.x) < Mathf.Abs(setDirection.y))
            {
                if(setDirection.y > 0){

                 SetProjectileSprite(Up);

                }else if(setDirection.y < 0){

                SetProjectileSprite(Down);
                }
              
            }

        }

        private void OnTriggerEnter2D(Collider2D player)
        {
            if(player.gameObject.CompareTag("Player"))
            {
                OneInstanceExists = false;
                Player.GetComponent<PlayerHP>().Playerhp -= Damage;
                Destroy(gameObject);
                

            }
        }

        
   
    }

}