using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;


namespace Samurai
{
    public enum Turn
    {
    Start,
    PlayerTurn,
    EnemyTurn,
    FinishedTurn,
    Won,
    Lost,
    BattleWon,

    }

    public class TurnHandler : MonoBehaviour
    {

    [Header("Turns")]
    public Turn turn; 
    private EnemyStatesHandler enemyAttackHandler;  
    [Header("Player")]
    public GameObject Slime;
    public GameObject playerfield;
    public GameObject playerUI;

    [Header("Player Attacks")]
    public GameObject AttackButtons;
    private bool PlayerActed;
    
    [Header("Player Attack Damage")]
    public int TackleDamage;
    public int SlashDamage;

    [Header("Battle Settings")]
    public EnemyProfile[] enemyProfile;
    private GameObject[] EnemyAttacks;
    public GameObject[] textbox;
    public GameObject WonBattleTextbox;
    private bool EnemyExists;
    public bool finSlimeAttack;
    

   
    

  
        
    
   

   
    void Start()
    {   

        int EnemyNumber = EnemyInfo.Enemyid;
    
    }

    // Update is called once per frame
    void Update()
    {
        EnemyAttacks = GameObject.FindGameObjectsWithTag("EnemyAttacks");
        
       
        if(turn == Turn.Start)
        {
             


                playerUI.SetActive(true);
                Slime.SetActive(false);
                playerfield.SetActive(false);
                AttackButtons.SetActive(false);
                finSlimeAttack = false;
                PlayerActed = false;

         
                foreach(EnemyProfile enemies in enemyProfile)
                {

                if(!EnemyExists)
                {
                int EnemyNumber = EnemyInfo.Enemyid;
                Instantiate(enemies.Enemies[EnemyNumber],Vector3.zero,Quaternion.identity);
                EnemyExists = true;
                }
                
                }
                foreach(GameObject enemies in EnemyAttacks)
                {
                enemies.GetComponent<EnemyStatesHandler>().enemyState = EnemyStates.Idle;
                }

            
           


        }else if(turn == Turn.PlayerTurn){
            Slime.SetActive(false);
            playerUI.SetActive(false);
            AttackButtons.SetActive(true);
        
           
            bool EnemyDead = false;
            if (finSlimeAttack)
            { 
                 foreach(GameObject enemies in EnemyAttacks)
                {
                   
                    GetComponent<Animator>().SetInteger("AttackIndex",0);
                    if(EnemyInfo.EnemyHP <= 0)
                     {
                         AttackButtons.SetActive(false);
                         enemies.GetComponent<EnemyStatesHandler>().EnemyDie();
                         EnemyDead = true;
                     }else{
                          enemies.GetComponent<EnemyStatesHandler>().Damaged();
                     }
                    
                }
            }

            if(EnemyDead)
            {
                WonBattleTextbox.SetActive(true);
                if(WonBattleTextbox.GetComponent<OverWorldDialogueHolder>().dialogueFinished)
                {
                    BackToOverWorldScene();
                }
            }else
            { 
                foreach(GameObject enemies in EnemyAttacks)
                {
                    if(enemies.GetComponent<EnemyStatesHandler>().HurtDone)
                    {
                    turn = Turn.EnemyTurn;
                    }
                }

            }



           
           
             
            

        }else if(turn == Turn.EnemyTurn){
            Slime.SetActive(true);
            playerUI.SetActive(false);
            playerfield.SetActive(true);
            AttackButtons.SetActive(false);
           
           
                
                
               
              
                bool FinTurn = true;
                foreach(GameObject attacks in EnemyAttacks)
                {
                    if(!attacks.GetComponent<EnemyStatesHandler>().AttackturnDone)
                    {
                        FinTurn = false;
                    }
                }
                

                if(FinTurn)
                {
                    
                    EnemyFinishedTurn();
                }

            
            
            

        }else if(turn == Turn.FinishedTurn){

      
            if(Slime.GetComponent<SlimeHP>().PlayerHP >=0)
            {
                turn = Turn.Won;
            }else{turn = Turn.BattleWon;}
        
            
           

        }else if(turn == Turn.Won){
            turn = Turn.Start;
            
            
            
        }else if(turn == Turn.Lost){
            Debug.Log("You Lose");
        }else if(turn == Turn.BattleWon)
        {

           
        }
    }

    
    private void EnemyFinishedTurn()
    {
        
        foreach(GameObject attacks in EnemyAttacks)
        {
            attacks.GetComponent<EnemyStatesHandler>().enemyState = EnemyStates.Idle;
        }
      
        turn = Turn.FinishedTurn;
    }

    public void PlayerTurn()
    {
        turn = Turn.PlayerTurn;
    }

    public void StartTurn()
    {
        playerUI.SetActive(false);
        turn = Turn.Start;
    }

    public void EscapeBattle()
    {
        foreach(EnemyProfile enemies in enemyProfile)
        {
            int EnemyNumber = EnemyInfo.Enemyid;
        }


        gameObject.SetActive(false);
        playerfield.SetActive(false);
        playerUI.SetActive(false);
        Slime.SetActive(true);
        

    }

 
    

    public void EndAttackAnimation()
    {
        finSlimeAttack = true;
        
    }
    
    /// Slime Attacks

    public void Tackle()
    {
        if(!PlayerActed)
        {
        EnemyInfo.EnemyHP -= TackleDamage;
        GetComponent<Animator>().SetInteger("AttackIndex",1);
        PlayerActed = true;
        }
        
    }

    public void Slash()
    {
       if(!PlayerActed)
       {
        EnemyInfo.EnemyHP -= SlashDamage;
        GetComponent<Animator>().SetInteger("AttackIndex",2);
        PlayerActed = true;

       }

        
    }
    private void BackToOverWorldScene()
    {
        if(Input.GetKey(KeyCode.X))
        {
            SceneManager.LoadScene("Overworld");
        }
        
    }

    
   
    }

}