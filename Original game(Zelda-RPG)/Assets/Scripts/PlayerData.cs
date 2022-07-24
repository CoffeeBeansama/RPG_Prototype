using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Samurai
{
    [CreateAssetMenu(fileName = "PlayerDataStorage")]
    [System.Serializable]
    public class PlayerData : ScriptableObject, ISerializationCallbackReceiver
    {
        public int PlayerMaxHealth;
        public int PlayerRuntimeHealth;
        public Vector2 PlayerInitialPosition;
        public static int PlayerHPData = 20;
        public static int PlayerItemData;
        public int CoinCount;
        public PlayerDirection PlayerDirection;

        public void OnAfterDeserialize()
        {
        PlayerRuntimeHealth = PlayerMaxHealth;
        }

         public void OnBeforeSerialize()
         {
           //PlayerMaxHealth = PlayerRuntimeHealth;
         }

        

    }   

    
    

    public enum PlayerDirection
    {
        Up,
        Down,
        Left,
        Right,
    }

    
  

   

     

}
