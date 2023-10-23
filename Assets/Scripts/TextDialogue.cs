using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextDialogue : MonoBehaviour
{
    public Text dialogueText;
    public string[] dialogueTexts;
    public bool isDialogue;
    public bool hasNextDialogue;
    public GameObject NextDialogue;
    public GameObject screenBackground;


    
    public int answerDataHolder;
    
    private void Start()
    {
        
        if (answerDataHolder > 5)
        {
            StartCoroutine(TypeText(dialogueTexts[0]));
        }
        else
        {
            StartCoroutine(TypeText(dialogueTexts[answerDataHolder]));
        }
       
           
            screenBackground = GameObject.Find("Background");
        
       
        
        //int randomIndex = Random.Range(0, dialogueTexts.Length);
        
     
       
        //Get answer data int
        

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

    //public void OnEnable()
    //{     
    //    int randomIndex = Random.Range(0, dialogueTexts.Length);
    //    StartCoroutine(TypeText(dialogueTexts[randomIndex]));
    //}

    public void SelfDispose()
    {
        if (screenBackground != null && screenBackground.activeSelf)
        {
            screenBackground.SetActive(false);
        }
        
        if (hasNextDialogue && NextDialogue != null) //IF THE DIALOGUE HAS NEXT CONVERSATION
        {
            NextDialogue.SetActive(true);
        }

        if(!isDialogue)  // IF END NARRATOR UI 
        {
            Debug.Log("CloseThis dialogue");
            Destroy(gameObject);         
        }

    }

   
}
