using UnityEngine;
using UnityEngine.SceneManagement;

namespace Samurai
{
    public class SceneTransit : MonoBehaviour
    {
        [Header("Scene Transport Settings")]
        public Vector2 PlayerPosition;
        public string SceneName;
        public PlayerData PlayerPositionStorage;
        private bool IstouchingthePortal;
        

        private void Start()
        {
            PlayerPositionStorage.PlayerInitialPosition = PlayerPosition;
        }

        private void Update()
        {
            if(IstouchingthePortal)
            {
                if(Input.GetKey(KeyCode.X))
                {
                    PlayerPositionStorage.PlayerInitialPosition = PlayerPosition;
                    SceneManager.LoadScene(SceneName);
                }
            }
        }



        private void OnTriggerStay2D(Collider2D player)
        {
            if(player.gameObject.CompareTag("Player"))
            {
                 
                IstouchingthePortal = true;
            }

        }

        private void OnTriggerExit2D(Collider2D player)
        {
            IstouchingthePortal = false;
        }
    
    }   
}

