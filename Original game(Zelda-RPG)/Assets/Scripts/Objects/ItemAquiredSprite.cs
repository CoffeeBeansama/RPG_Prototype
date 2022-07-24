using UnityEngine;


namespace Samurai
{
    public class ItemAquiredSprite : MonoBehaviour
    {

        public ItemIndex itemIndex;
        public SpriteRenderer spriteRenderer;
      
        

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        public void Update()
        {
            int itemId = itemIndex.ItemID;
            spriteRenderer.sprite = itemIndex.ItemSprite[itemId];
        }

    
    }

}

