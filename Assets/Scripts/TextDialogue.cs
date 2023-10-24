using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextDialogue : MonoBehaviour
{
    public Text dialogueText;
    public string[] dialogueTexts;
    public bool isDialogue;
    public bool hasNextDialogue;
    public GameObject[] NextDialogue;
    public GameObject screenBackground;


    public int answerDataHolder;
    
    private void Start()
    {
        
        if (answerDataHolder == 0)
        {
            StartCoroutine(TypeText(dialogueTexts[0]));
        }
        else
        {
            StartCoroutine(TypeText(dialogueTexts[answerDataHolder]));
        }  
            screenBackground = GameObject.Find("Background");
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
        if (screenBackground != null && screenBackground.activeSelf)
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
