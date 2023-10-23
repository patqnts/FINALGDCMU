using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISelectedStory : MonoBehaviour
{
    public string sceneNameToLoad;

    public void LoadSceneByName()
    {
        // Load the scene by name
        SceneManager.LoadScene(sceneNameToLoad);
    }
}
