using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Samurai
{
    public class OverWorldDialogue : DialogueSystem
    {
    private Text textHolder;
    [Header ("Text Options")] /// Header creates easy to see labels on top inspector
    [SerializeField]private string Texts;
    [SerializeField]private Color textcolor;
    [SerializeField]private Font textfont;

    [Header("Time parameters")]
    [SerializeField] private float delay;
    [SerializeField] private float LineDelays;

    [Header("Sound System")]
    [SerializeField] private AudioClip sfx;

    [Header("Character")]
    [SerializeField] private Sprite Characterportrait;
    [SerializeField] private Image ImageHolder;
    

    private IEnumerator lineAppear;
   
  



    private void Awake()
    {
        
        ImageHolder.sprite = Characterportrait;
        ImageHolder.preserveAspect = true;
    }


     private void OnEnable()
    {
        ResetLine();
        lineAppear = WriteText(Texts, textHolder, textcolor, textfont, delay, sfx, LineDelays);
        StartCoroutine(lineAppear);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
           
           if(textHolder.text != Texts)
          {
            
            StopCoroutine(lineAppear);
            textHolder.text = Texts;
          }else
          {
             
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