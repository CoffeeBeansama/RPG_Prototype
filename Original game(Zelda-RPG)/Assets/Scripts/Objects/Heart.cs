using UnityEngine;

namespace Samurai

{
    public class Heart : MonoBehaviour
    {
        public PlayerData playerHPHolder;
        public int HPRecover;

        public AudioClip HeartRegensfx;


        

        private void OnTriggerEnter2D(Collider2D player)
        {
            if(player.gameObject.CompareTag("Player"))
            {
                playerHPHolder.PlayerRuntimeHealth += HPRecover;
                Destroy(gameObject);
                SoundManager.instance.PlaySound(HeartRegensfx);
               
            }
        }
    
    }
}