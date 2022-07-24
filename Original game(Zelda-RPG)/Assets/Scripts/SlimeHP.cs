using UnityEngine;

namespace Samurai
{
    public class SlimeHP : MonoBehaviour
    {
        [Header("HP Settings")]
        public int PlayerHP;
        public int PlayerMaxHP;

       void Update()
       {

           if(PlayerHP <= 0)
           {
               PlayerDeath();
           }

       }

       private void PlayerDeath()
       {
           Debug.Log("Dead");
       }
    
    }
}