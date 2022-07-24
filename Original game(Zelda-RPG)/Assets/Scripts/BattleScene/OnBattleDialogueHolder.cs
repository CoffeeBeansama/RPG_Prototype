using System.Collections;
using UnityEngine;

namespace Samurai
{
    

public class OnBattleDialogueHolder : MonoBehaviour
{
    private IEnumerator dialogSeq;

    private void OnEnable()
    {
        
        dialogSeq = DialogueSequence();
        StartCoroutine(dialogSeq);
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            DeactiveLine();
            gameObject.SetActive(false);
            StopCoroutine(dialogSeq);
        }
    }
    private IEnumerator DialogueSequence()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            DeactiveLine();
            transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitUntil(() => transform.GetChild(i).GetComponent<OnBattleDialogue>().LineFinished);
        }
        gameObject.SetActive(false);
    }

    private void DeactiveLine()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

    }
}
}