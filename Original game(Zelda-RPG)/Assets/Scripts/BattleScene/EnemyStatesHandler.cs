using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Samurai
{
    public enum EnemyStates
    {
        Idle,  /// Index = 0
        Hurt,  /// Index = 1
        Attack, /// Index = 2-5
        Die  /// Index = 10
    }

    public class EnemyStatesHandler : MonoBehaviour
    {
        [Header("Enemy Info")]
        [SerializeField]public EnemyStates enemyState;
        public bool AttackturnDone;
        public bool HurtDone;
        public int StateNumber;
        private bool StartAttack;
        private bool OnBattle;
        private bool finDieAnimation;
        private GameObject[] PlayerAttacks;
       
      
   

        private void Update()
        {
            
            PlayerAttacks = GameObject.FindGameObjectsWithTag("PlayerAttacks");
            if(enemyState == EnemyStates.Idle)
            {
                AttackturnDone = false;
                GetComponent<Animator>().SetInteger("EnemyState",0);
                foreach(GameObject playerattacks in PlayerAttacks)
                {
                     if(playerattacks.GetComponent<EndAttackAnimation>().EndofAttack)
                     {
                         
                         enemyState = EnemyStates.Hurt;
                     }
                }
            }else if(enemyState == EnemyStates.Hurt)
            {
               
                  GetComponent<Animator>().SetInteger("EnemyState",1);
                
            }else if(enemyState == EnemyStates.Attack)
            {
                HurtDone = false;
                 if(StartAttack)
                 {
                     int randomAttack = Random.Range(2,StateNumber);
                     GetComponent<Animator>().SetInteger("EnemyState",randomAttack);
                     StartAttack = false;
                 }
            }else if(enemyState == EnemyStates.Die)
            {
                    
                    if(finDieAnimation)
                    {
                    EnemyInteract.EnemyDefeated = true;
                    if(Input.GetKey(KeyCode.X))
                        {
                             SceneManager.LoadScene("Overworld");
                        }
                    }
                  
                    
        
                
                
            }
            
            
         

           
        }
    


        public void AttackFinished()
        {
            AttackturnDone = true;
        }

        public void Damaged()
        {
            
            enemyState = EnemyStates.Hurt;
            
        }

        public void HurtFinished()
        {
            StartAttack = true;
            enemyState = EnemyStates.Attack;
            HurtDone = true;
            
        }
       

        public void EnemyDie()
        {
            enemyState = EnemyStates.Die;
            GetComponent<Animator>().SetInteger("EnemyState",10);
        }
        
        public void EnemyDeadAnimation()
        {
           finDieAnimation = true;

        }

        
        
       
    }   
}
