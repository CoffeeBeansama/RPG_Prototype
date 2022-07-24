using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Samurai
{
    public class DialogueSystem : MonoBehaviour
    {
        public bool LineFinished {get; protected set;}

        protected IEnumerator WriteText(string input, Text textholder, Color textColor, Font textfont, float delay, AudioClip sfx, float delaybetweenlines)
        {
            textholder.color = textColor;
            textholder.font = textfont;

            for(int i = 0; i < input.Length; i++)
            {
                textholder.text += input[i];
                SoundManager.instance.PlaySound(sfx);

                yield return new WaitForSeconds(delay);
            }
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.X));
            
            LineFinished = true;
        }

    }


    public class OnBattleDialogue : DialogueSystem
    {
        private Text textHolder;

        [Header("Text Options")]
        [SerializeField] private string Texts;
        [SerializeField] private Color TextColor;
        [SerializeField] private Font TextFont;

        [Header("Time Parameters")]
        [SerializeField] private float delay;
        [SerializeField] private float LineDelays;

        [Header("Sound System")]
        [SerializeField] private AudioClip sfx;

        public GameObject TurnManager;
        private IEnumerator lineDisplay;

        private void OnEnable()
        {
            ResetLine();
            lineDisplay = WriteText(Texts, textHolder, TextColor, TextFont, delay, sfx, LineDelays);
            StartCoroutine(lineDisplay);
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                if(textHolder.text != Texts)
                {
                    StopCoroutine(lineDisplay);
                    textHolder.text = Texts;
                }else
                {
                    TurnManager.GetComponent<TurnHandler>().turn = Turn.EnemyTurn;
                    LineFinished = true;
                }

            }
        }

        private void ResetLine()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";
            LineFinished = false;
           
        }

    }      
}