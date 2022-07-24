using UnityEngine;

namespace Samurai
{
    public class EnemyInteract : MonoBehaviour
    {

        [Header("DialogueBox Used")]
        public GameObject DialogueBox;
        public new GameObject camera; 


        public bool DialogueBoxisActive {get; private set;}
        public static bool EnemyDefeated;
     


        public void ActivateDialogue()
        {
          
            DialogueBox.SetActive(true);
            
        }
        private void Update()
        {
           
            
            if(DialogueBox.activeInHierarchy)
            {
                DialogueBoxisActive = true;
            }else{
                DialogueBoxisActive = false;
            }
        }
     
     

        
    
    }

}