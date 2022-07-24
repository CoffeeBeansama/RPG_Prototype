using UnityEngine;
using UnityEngine.SceneManagement;

namespace Samurai
{
    public class HortonInteract : EnemyInteract
    {
    
        private void OnTriggerEnter2D(Collider2D Player)
        {
            if(Player.gameObject.tag == "Player")
            {
                
                EnemyInfo.Enemyid = 1;
            }
        }

        private void Update()
        {
            if(!HortonHp.HortonDefeated )
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