using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextDialogue : MonoBehaviour
{
    public Text dialogueText;
    public string[] dialogueTexts;
    

    IEnumerator TypeText(string text)
    {
        dialogueText.text = "";

        foreach (char letter in text)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f); // Adjust the typing speed as desired
        }
    }

    public void OnEnable()
    {     
        int randomIndex = Random.Range(0, dialogueTexts.Length);
        StartCoroutine(TypeText(dialogueTexts[randomIndex]));
    }
}
