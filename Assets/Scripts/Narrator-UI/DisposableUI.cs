using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisposableUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject NextUI;
    public Transform parent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelfDispose()
    {
        Destroy(gameObject);
    }

    public void NextUIObj()
    {
        NextUI.gameObject.SetActive(true);
    }
}
