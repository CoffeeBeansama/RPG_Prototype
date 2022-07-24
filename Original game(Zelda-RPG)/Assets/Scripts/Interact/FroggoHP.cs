using UnityEngine;

namespace Samurai
{
    public class FroggoHP : MonoBehaviour
    {
        public int Froggohp;
        public static bool FroggoDefeated;


        private void Start()
        {
            
           EnemyInfo.EnemyHP = Froggohp;
        }

        private void Update()
        {
            if(EnemyInfo.EnemyHP <= 0)
            {
                FroggoDefeated = true;
            }
        }


  
    }

}

