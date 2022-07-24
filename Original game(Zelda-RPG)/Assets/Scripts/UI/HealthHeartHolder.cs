using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Samurai
{


    public class HealthHeartHolder : MonoBehaviour
    {
        public GameObject HeartPrefab;
        public PlayerData playerHealth;
        List<PlayerHealthHearts> hearts = new List<PlayerHealthHearts>();


        
        private void Update()
        {
            DrawHearts();
        }

        public void DrawHearts()
        {
            ClearHearts();
           
            float maxHealthRemainder = playerHealth.PlayerMaxHealth % 2;
            int heartsToMake = (int)((playerHealth.PlayerMaxHealth / 2) + maxHealthRemainder);

            for(int i = 0; i < heartsToMake; i++)
            {
               
                CreateEmptyHearts();
            }

            for(int i = 0; i < hearts.Count; i++)
            {
                int StatusRemainder = (int)Mathf.Clamp(playerHealth.PlayerRuntimeHealth - (i*4),0,4);
                hearts[i].SetHeartImage((HeartStatus)StatusRemainder);
            }

        }


        public void CreateEmptyHearts()
        {
            GameObject newHeart = Instantiate(HeartPrefab);
            newHeart.transform.SetParent(transform);

            PlayerHealthHearts heartComponent = newHeart.GetComponent<PlayerHealthHearts>();
            heartComponent.SetHeartImage(HeartStatus.Empty);
            hearts.Add(heartComponent);
        }

        public void ClearHearts()
        {
            foreach (Transform hearts in transform)
            {
                Destroy(hearts.gameObject);
            }

            hearts = new List<PlayerHealthHearts>();
        }



    }
}