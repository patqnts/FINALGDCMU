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
    private void Start()
    {
        int randomIndex = Random.Range(0, dialogueTexts.Length);
        StartCoroutine(TypeText(dialogueTexts[0]));
        screenBackground = GameObject.Find("Background");
       

    }
    IEnumerator TypeText(string text)
    {
        dialogueText.text = "";

        foreach (char letter in text)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.03f); // Adjust the typing speed as desired
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
            Destroy(gameObject);         
        }

    }

   
}
