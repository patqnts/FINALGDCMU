using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TextDialogue : MonoBehaviour
{
    public Text dialogueText;
    public string[] dialogueTexts;
    public bool isDialogue;
    public bool hasNextDialogue;
    public GameObject[] NextDialogue;
    public GameObject screenBackground;

    public VideoClip[] myClips;
    public VideoPlayer clipHolder;


    public int answerDataHolder;
    
    private void Start()
    {
        clipHolder = GameObject.Find("ClipHolder").GetComponent<VideoPlayer>();
        if (answerDataHolder == 0 )
        {
            StartCoroutine(TypeText(dialogueTexts[0]));


            PlayVideoClip(0);

        }
        else
        {
            StartCoroutine(TypeText(dialogueTexts[answerDataHolder]));

            
            PlayVideoClip(answerDataHolder);
        }
        screenBackground = GameObject.Find("Background");
    }
    public void PlayVideoClip(int index)
    {
        if (index < myClips.Length && myClips != null)
        {
            clipHolder.clip = myClips[index];
            clipHolder.Play();
        }
    }

    IEnumerator TypeText(string text)
    {
        dialogueText.text = "";

        foreach (char letter in text)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.015f); // Adjust the typing speed as desired
        }
       
        Invoke("SelfDispose", 3f);

    }

    public void SelfDispose()
    {
        if (screenBackground != null)
        {
            Destroy(screenBackground);
        }
        
        if (hasNextDialogue) //IF THE DIALOGUE HAS NEXT CONVERSATION
        {
            if(NextDialogue.Length > 1 && NextDialogue != null)
            {
                NextDialogue[answerDataHolder].SetActive(true);
            }
            else
            {
                NextDialogue[0].SetActive(true);

            }
        }

        if(!isDialogue)  // IF END NARRATOR UI 
        {
            Debug.Log("Close This dialogue");
            Destroy(gameObject);         
        }

    }

   
}
