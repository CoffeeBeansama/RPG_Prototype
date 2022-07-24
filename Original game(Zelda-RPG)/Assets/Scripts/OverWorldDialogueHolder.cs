using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Samurai
{
    public class OverWorldDialogueHolder : MonoBehaviour
    {
        private IEnumerator dialogueSeq;
        public bool dialogueFinished;
        private new GameObject camera;

        private void Awake()
        {
            camera = GameObject.FindGameObjectWithTag("MainCamera");
        }
  
        private void OnEnable()
        {
            dialogueSeq = dialogueSequence();
            StartCoroutine(dialogueSeq);
        }

        private void Update()
        {
            if(Input.GetKey(KeyCode.Space))
            {
                DeactiveLine();
                this.gameObject.SetActive(false);
                StopCoroutine(dialogueSeq);
            }
        }
        private IEnumerator dialogueSequence()
        {
            if(!dialogueFinished)
            {
                for(int i = 0; i < transform.childCount -1 ; i++)
                 {
                DeactiveLine();
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<OverWorldDialogue>().LineFinished);
                 }
            }else{
                int index = transform.childCount -1;
               
                 DeactiveLine();
                transform.GetChild(index).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(index).GetComponent<OverWorldDialogue>().LineFinished);
                  
                
            }
            dialogueFinished = true;
            gameObject.SetActive(false);
            

        }

        private void DeactiveLine()
        {
             for(int i = 0;  i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}