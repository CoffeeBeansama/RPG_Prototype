using UnityEngine;

namespace Samurai
{
    public class PlayerHP : MonoBehaviour
    {
        [Header("HP Settings")]
        public int Playerhp;
        public int PlayerMaxHP;
        public PlayerData PlayerDataStorage;

        private void Start()
        {
            Playerhp = PlayerDataStorage.PlayerRuntimeHealth;
            PlayerMaxHP = PlayerDataStorage.PlayerMaxHealth;
        }

       void Update()
       {
          Playerhp = PlayerDataStorage.PlayerRuntimeHealth;




           if(Playerhp <= 0)
           {
               PlayerDeath();
           }

           if(Playerhp >= PlayerMaxHP)
           {
               Playerhp = PlayerMaxHP;
           }

           if(PlayerDataStorage.PlayerRuntimeHealth >= PlayerDataStorage.PlayerMaxHealth)
           {
              PlayerDataStorage.PlayerRuntimeHealth = PlayerDataStorage.PlayerMaxHealth;
           }

       }

       private void PlayerDeath()
       {
           ///Things to do
       }
    
    }
}