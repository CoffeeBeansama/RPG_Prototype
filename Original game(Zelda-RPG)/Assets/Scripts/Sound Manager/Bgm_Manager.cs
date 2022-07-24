using UnityEngine;

namespace Samurai
{
    public class Bgm_Manager : MonoBehaviour
    {
        
        public AudioSource BGM;
        private bool IstouchingthisArea;
        private bool AlreadyplayingtheBGM;

        private void Update()
        {
            if(IstouchingthisArea)
            {
                if(!AlreadyplayingtheBGM)
                {
                    BGM.Play();
                    AlreadyplayingtheBGM = true;
                    
                }
                
            }
        }

        private void OnTriggerEnter2D(Collider2D player)
        {
            if(player.gameObject.CompareTag("Player"))
            {
                IstouchingthisArea = true;
            }
        }

        private void OnTriggerExit2D(Collider2D player)
        {
            if(player.gameObject.CompareTag("Player"))
            {
            BGM.Stop();
            IstouchingthisArea = false;
            AlreadyplayingtheBGM = false;
            }
        }

        
    }

}

