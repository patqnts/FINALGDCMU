using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectStoryScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Image selectImage;


    public Image TargetImage;
    public Text TargetString;


    [TextArea]
    public string sypnosis;
    void Start()
    {
        selectImage = GetComponent<Image>();
    }

    public void PassStoryDetails()
    {
        TargetString.text= sypnosis;
        TargetImage.sprite = selectImage.sprite;
    }
}
