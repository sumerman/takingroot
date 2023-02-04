using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Test : MonoBehaviour
{
    public Button btn;
    public Sprite cardSprite;
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
        Debug.Log("Click");

        UIDialogHistory hist = GameObject.FindObjectOfType<UIDialogHistory>();
        hist.AddPhrase("foooo");

        UIDeck deck = GameObject.FindObjectOfType<UIDeck>();
        deck.AddCard(cardSprite, "Bar!");
    }
}
