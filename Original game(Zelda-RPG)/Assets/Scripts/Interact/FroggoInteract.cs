using UnityEngine;


namespace Samurai
{
    public class FroggoInteract : EnemyInteract
    {

        
    
     
        private void OnTriggerEnter2D(Collider2D Player)
        {
            
            if(Player.gameObject.tag == "Player")
            {   
                EnemyInfo.Enemyid = 0;
            }
        }

        private void Update()
        {
            
            
            if(!FroggoHP.FroggoDefeated)
            { 
                if(DialogueBox.GetComponent<OverWorldDialogueHolder>().dialogueFinished)
                {
                 StartBattle();
                }
   
            }else{DialogueBox.GetComponent<OverWorldDialogueHolder>().dialogueFinished = true;}

            

           
           
        }

        private void StartBattle()
        {
             camera.GetComponent<CameraSettings>().StartBattleTransition();   
        }
        
    
    }
}