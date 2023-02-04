using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Test : MonoBehaviour
{
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
    }
    
    void Awake()
    {
        Debug.Log("foo " + btn);
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnClick() 
    {
        DialogHistory hist = GameObject.FindObjectOfType<DialogHistory>();
        hist.AddPhrase("foooo");
        Debug.Log("Click");
    }
}
