using UnityEngine;
using UnityEngine.UI;

namespace Samurai
{
    public class PlayerHPUI : MonoBehaviour
    {

        private PlayerHP playerHPManager;
        public Sprite PlayerFullHeart;
        public Sprite PlayerThreefourthsHeart;
        public Sprite PlayerHalfHeart;
        public Sprite PlayerQuarterHeart;
        public Sprite PlayerEmptyHeart;


        public bool[] HeartIsEmpty;

        public PlayerData PlayerDataStorage;
        
    
        public Image[] PlayerHearts;

        public void Start()
        {
            for(int i = 0; i < PlayerHearts.Length; i++)
            {
                PlayerHearts[i].sprite = PlayerFullHeart;
            }
        }

        private void Awake()
        {

            playerHPManager = FindObjectOfType<PlayerHP>();
        }

        private void Update()
        {
            

           

            HeartSpriteChange();

           


        }

        private void KeepOtherHearts()
        {

        }

        private void HeartSpriteChange()
        {
            int PlayerTempHealth = PlayerDataStorage.PlayerRuntimeHealth;
            int PlayerMaxHealth = PlayerDataStorage.PlayerMaxHealth;

            
            for(int i = 0; i < PlayerHearts.Length; i++)
            {
               
                 if(i >= PlayerTempHealth)
                 {
                PlayerHearts[i].sprite = PlayerFullHeart;
                
                 }else if(i == PlayerTempHealth-1)
                {
                PlayerHearts[i].sprite = PlayerThreefourthsHeart;

                }else if(i == PlayerTempHealth-2)
                 {
                 PlayerHearts[i].sprite = PlayerHalfHeart;
                 }else if(i == PlayerTempHealth-3)
                 {
                 PlayerHearts[i].sprite = PlayerQuarterHeart;
                }else{
                PlayerHearts[i].sprite = PlayerEmptyHeart;
                

                }
            }

                
        }



      


    
    }

}

