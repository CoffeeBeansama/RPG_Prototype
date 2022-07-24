using UnityEngine;

namespace Samurai
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance {get; private set;}
        private AudioSource source;

        private void Awake()
        {
            instance = this;
            source = GetComponent<AudioSource>();
        }

        public void PlaySound(AudioClip sfx)
        {
            source.PlayOneShot(sfx);
        }
     
    }   
}