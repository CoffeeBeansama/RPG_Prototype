using UnityEngine;

namespace Samurai
{
    public class Coin : MonoBehaviour
    {
        public int CoinValue;
        public Items Coins;
        public AudioClip CoinAcquireSfx;



        private void OnTriggerEnter2D(Collider2D player)
        {
            if(player.gameObject.CompareTag("Player"))
            {
                SoundManager.instance.PlaySound(CoinAcquireSfx);
                Coins.ItemHave += CoinValue;
                Destroy(gameObject);

            }
        }

    }
}