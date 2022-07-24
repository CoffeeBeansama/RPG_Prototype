using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Samurai
{

    public class CameraSettings : MonoBehaviour
    {
        [Header("Camera Settings")]
        public Transform Player;
        private GameObject[] dialogueHolder;
        public bool StartBattle;
    
        
         private void Update()
          {
              transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y,transform.position.z);

          }
          
        public void StartBattleTransition()
        {
             int RandomAnimation = Random.Range(0,1);
             GetComponent<Animator>().SetInteger("AnimationNum",RandomAnimation);
             Invoke(nameof(ChangeScene),1.20f);
        }

        private void ChangeScene()
        {
        SceneManager.LoadScene("BattleScene");
        }
    }   


}