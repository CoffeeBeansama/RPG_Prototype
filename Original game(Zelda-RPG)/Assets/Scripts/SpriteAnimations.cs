using UnityEngine;

namespace Samurai
{
    public class SpriteAnimations : MonoBehaviour
    {
        public Sprite idlesprite;
        public Sprite[] animationSprites;
        private SpriteRenderer spriteRenderer;
        public float animationTime = 0.25f;
        private int animationFrame;

        public bool loop = true;
        public bool idle = true;


        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            spriteRenderer.enabled = true;
            
        }
    
        private void OnDisable()
        {
            spriteRenderer.enabled = false;
        }

        private void Start()
        {
            InvokeRepeating(nameof(NextFrame),animationTime,animationTime);
            
        }

        private void NextFrame()
        {
            animationFrame++;

            if(loop && animationFrame >= animationSprites.Length)
            {
                animationFrame = 0;
            }

            if(idle)
            {
                spriteRenderer.sprite = idlesprite;
            }else if(animationFrame >=00 && animationTime < animationSprites.Length)
            {
                spriteRenderer.sprite = animationSprites[animationFrame];
            }
        }

        
     
    }

}
