using UnityEngine;

namespace Samurai
{
    public class ObjectInteract : MonoBehaviour
    {
        [Header("Dialogue Box that is using")]
        public GameObject DialogueBox;
        private bool IstouchingtheObject;
       

        private void Update()
        {
            if(IstouchingtheObject)
            {
                if(Input.GetKeyDown(KeyCode.X))
                {
                    DialogueBox.SetActive(true);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D player)
        {
            if(player.gameObject.CompareTag("Player"))
            {
                IstouchingtheObject = true;
            }

        }

        private void OnTriggerExit2D(Collider2D player)
        {
            IstouchingtheObject = false;
        }
    }

}

