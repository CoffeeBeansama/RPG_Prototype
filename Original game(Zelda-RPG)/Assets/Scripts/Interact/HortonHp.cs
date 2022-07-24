using UnityEngine;

namespace Samurai
{
    public class HortonHp : MonoBehaviour
    {
        public int Hortonhp;
        public static bool HortonDefeated;
    
        private void Start()
        {
           
            EnemyInfo.EnemyHP = Hortonhp;
        }

        private void Update()
        {
            if(EnemyInfo.EnemyHP <= 0)
            {
                HortonDefeated = true;
            }
        }

   
  
    }   


}
