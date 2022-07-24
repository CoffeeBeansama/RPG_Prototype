using UnityEngine;
using UnityEngine.Events;
namespace Samurai 
{

    public class PlayerDetect : MonoBehaviour
    {
        public int Damage;
        public AudioClip HitSfx;
        public PlayerData PlayerDataStorage;
        public GameObject HitIndicator;
        private bool PlayerDamaged;

        
 
       


        private void Start()
        {
            PlayerDamaged = false;
        }
       

        private void OnTriggerEnter2D(Collider2D Player)
        {
            if(Player.gameObject.CompareTag("Player"))
            {
                Instantiate(HitIndicator,Player.transform.position,Quaternion.identity);
                SoundManager.instance.PlaySound(HitSfx);

                if(!PlayerDamaged)
                {
                
                    PlayerDataStorage.PlayerRuntimeHealth -= Damage;
                    PlayerDamaged = true;
                
                }
                
                

            }

        }


      

        public void DestroySelf()
        {
            
            Destroy(gameObject);
        }

   
    }
}
