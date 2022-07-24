using UnityEngine;

namespace Samurai
{


    public class EnemyDetect : MonoBehaviour
    {
        
        public int Damage;
        public AudioClip HitSfx;
        public GameObject WeaponSparkHit;
        public GameObject HitIndicator;


      

        private void OnTriggerEnter2D(Collider2D other)
        {
                if(other.gameObject.CompareTag("Enemies"))
                {
                    SoundManager.instance.PlaySound(HitSfx);
                    Instantiate(HitIndicator,other.transform.position,Quaternion.identity);
                    Instantiate(WeaponSparkHit,other.transform.position,Quaternion.identity);
                    other.GetComponent<EnemyScript>().EnemyHP -= Damage;
                }
            
        }
    
    }
}