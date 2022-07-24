using UnityEngine;
using UnityEngine.UI;

namespace Samurai
{
    public class ItemQuantity : MonoBehaviour
    {   
        public Text ItemText;
        public Items items;

        private void Update()
        {
            ItemText.text = items.ShurikenOnHand.ToString();
            ItemText.text = items.ItemHave.ToString();
        }
   
    }

}
