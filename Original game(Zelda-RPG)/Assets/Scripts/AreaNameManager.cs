using UnityEngine;

namespace Samurai
{
    public class AreaNameManager : MonoBehaviour
    {
        public GameObject AreaName;

        private void OnTriggerEnter2D(Collider2D player)
        {
            if(player.gameObject.CompareTag("Player"))
            {
                AreaName.SetActive(true);
                Invoke(nameof(HideAreaName),3.5f);
            }
        }

        private void HideAreaName()
        {
            AreaName.SetActive(false);


        }

    
    }

}

