using UnityEngine;
using System.Collections;

namespace Samurai
{
    public class EnemyScript : MonoBehaviour
    {
        [Header("Enemy Info")]
        public EnemyState MyState;

        [Range(0,10)]
        public float EnemySpeed;
        public float AttackSpeed;
        public float itemspawnChance = 0.4f;
        public GameObject[] SpawnableObjects;
        public GameObject EnemyAttack;
        public SpriteAnimations Up;
        public SpriteAnimations Down;
        public SpriteAnimations Left;
        public SpriteAnimations Right;
        private SpriteAnimations ActiveSpriteRenderer;
        public int EnemyHP;
        public float EnemyProximity;
        public float EnemyMeleeRange;
        private GameObject Player;
        private new Rigidbody2D rigidbody;
        public bool IsAMeleeCharacter;
        public bool IsARangeCharacter;
        public bool IsHurt;
        private bool EnemyAlreadyAttacked;
        private Vector3 InitialPosition;
        
     

        public void Start()
        {
            InitialPosition = transform.position;
            SetSpriteDirection(Vector2.down,Down);
            rigidbody = GetComponent<Rigidbody2D>();
            Player = GameObject.FindGameObjectWithTag("Player");
            MyState = EnemyState.Idle;
        }

        public void Update()
        {

            StartCoroutine(CheckifStillAlive());
          
            switch(MyState)
            {
                case EnemyState.Idle:

                IdleState();
                   
                break;

                case EnemyState.Chase:


                ChaseState();

                break;

                case EnemyState.Hurt:
             
                break;

                case EnemyState.Attack:

                AttackState();


                break;

                case EnemyState.BackToOriginalPosition:

                BackToOriginalPosition();

                break;
                
                case EnemyState.Die:

                DeadState();

                break;
                
            }

        

        }

 

      

        private void IdleState()
        {
            
             SetSpriteDirection(Vector2.down,Down);
            if(PlayerInIdleProximity())
            {
                MyState = EnemyState.Chase;
            }

        }

        private void ChaseState()
        {
            Vector3 NewPosition = Vector3.MoveTowards(transform.position,Player.transform.position, EnemySpeed * Time.deltaTime);
            SetAnimationDirection(NewPosition - transform.position); 
            rigidbody.MovePosition(NewPosition);

            if(FarfromInitialPosition())
            {
                MyState = EnemyState.BackToOriginalPosition; 
            }
            if(PlayerInAttackRange())
            {
                MyState = EnemyState.Attack;
            }
        }

        private void AttackState()
        {
            if(IsAMeleeCharacter && !EnemyAlreadyAttacked)
            {
                StartCoroutine(InitiateAttack());
            }

            if(IsARangeCharacter && !EnemyAlreadyAttacked)
            {
                 StartCoroutine(InitiateAttack());
            }

            if(!PlayerInAttackRange())
            {
                MyState = EnemyState.Chase;
            }
          
        }


        private void BackToOriginalPosition()
        {
           

            Vector3 NewPosition = Vector3.MoveTowards(transform.position,InitialPosition, EnemySpeed * Time.deltaTime);
            SetAnimationDirection(NewPosition - transform.position); 
            rigidbody.MovePosition(NewPosition);


            if(transform.position == InitialPosition)
            {
                MyState = EnemyState.Idle;
            }else if(PlayerInIdleProximity())
            {
                 StartCoroutine(GoBackToChaseState());
            }

            

        }

        IEnumerator GoBackToChaseState()
        {
            if(PlayerInIdleProximity())
            {
                yield return new WaitForSeconds(2f);
                MyState = EnemyState.Chase;
            }
        }


        IEnumerator InitiateAttack()
        {
            if(IsAMeleeCharacter! && !EnemyAlreadyAttacked)
            {
                Instantiate(EnemyAttack,Player.transform.position,Quaternion.identity);
                EnemyAlreadyAttacked = true;
                yield return new WaitForSeconds(AttackSpeed);
                EnemyAlreadyAttacked = false;
            }

            if(IsARangeCharacter && !EnemyAlreadyAttacked)
            {
                Instantiate(EnemyAttack,transform.position,Quaternion.identity);
                EnemyAlreadyAttacked = true;
                yield return new WaitForSeconds(AttackSpeed);
                EnemyAlreadyAttacked = false;
            }


            

        }

        IEnumerator EnemyHurt()
        {
            
            Rigidbody2D self = GetComponent<Rigidbody2D>();

            MyState = EnemyState.Hurt;
            yield return new WaitForSeconds(.10f);
            self.velocity = Vector2.zero;
            self.isKinematic = true;
            MyState = EnemyState.Chase;
             
        }

        private void OnTriggerEnter2D(Collider2D weapon)
        {
            if(weapon.gameObject.CompareTag("Weapons"))
            {
                IsHurt = true;
                StartCoroutine(EnemyHurt());
            }

        }
        
        private bool FarfromInitialPosition()
        {
            if(Vector3.Distance(InitialPosition,transform.position) > EnemyProximity )
            {
                return true; 
            }

            return false;

        }
    

        private bool PlayerInIdleProximity()
        {
            if(Vector3.Distance(Player.transform.position,transform.position) < EnemyProximity && !PlayerInAttackRange())
            {
               
                 return true;
            }
           
            return false;

        }


        private void SetAnimationDirection(Vector2 setDirection)
        {

            if(Mathf.Abs(setDirection.x) > Mathf.Abs(setDirection.y))
            {
                if(setDirection.x > 0){

                  SetSpriteDirection(Vector2.right,Right);
                  

                }else if(setDirection.x < 0){

                   SetSpriteDirection(Vector2.left,Left);
                }

            }else if(Mathf.Abs(setDirection.x) < Mathf.Abs(setDirection.y))
            {
                if(setDirection.y > 0){

                 SetSpriteDirection(Vector2.up,Up);

                }else if(setDirection.y < 0){

                SetSpriteDirection(Vector2.down,Down);
                }
              
            }else{
                SetSpriteDirection(Vector2.zero,ActiveSpriteRenderer);
            }
        }

        private void SetSpriteDirection(Vector2 newDirection, SpriteAnimations spriteRenderer)
        {
            Vector2 direction = Vector2.zero;
            direction = newDirection;

            
            Up.enabled = spriteRenderer == Up;
            Down.enabled = spriteRenderer == Down;
            Left.enabled = spriteRenderer == Left;
            Right.enabled = spriteRenderer == Right;
            ActiveSpriteRenderer = spriteRenderer;
            ActiveSpriteRenderer.idle = direction == Vector2.zero;
            

        }
        
      

        private bool PlayerInAttackRange()
        {
             if(Vector3.Distance(transform.position,Player.transform.position) < EnemyMeleeRange)
            {
                 return true;
            }
           
            return false;

        }

        IEnumerator CheckifStillAlive()
        {
            if(EnemyDead())
            {
                MyState = EnemyState.Die;
                 yield return new WaitForSeconds(1f);
            }
           



        }

        private void DeadState()
        {
            if(SpawnableObjects.Length > 0 && Random.value < itemspawnChance)
            {
            int RandomObject = Random.Range(0,SpawnableObjects.Length);
            Instantiate(SpawnableObjects[RandomObject],transform.position,Quaternion.identity);
            
            }
            Destroy(gameObject);
    
        }
        private bool EnemyDead()
        {
            if(EnemyHP <= 0)
            {
                MyState = EnemyState.Die;
                return true;
            }
            return false;
        }

    
    }

}