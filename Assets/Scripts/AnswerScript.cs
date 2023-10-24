using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public TextDialogue targetText;
    public TextDialogue[] responseTargetText;
    public GameObject AnswerGameObject;
    public GameObject QuestionGameObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PassAnswerToText(string myAnswer)
    {
        AnswerGameObject.SetActive(true);   //ACTIVATE THE ANSWER
        Destroy(QuestionGameObject);         //DESTROY THE QUESTION
        targetText.dialogueTexts[0] = myAnswer; 
        Destroy(gameObject);                //DESTROY SELF
    }

    public void PassAnswerData(int myAnswerInt)
    {
        for(int i = 0; i < responseTargetText.Length; i++)
        {
            responseTargetText[i].answerDataHolder = myAnswerInt;
        }
         
    }
}
