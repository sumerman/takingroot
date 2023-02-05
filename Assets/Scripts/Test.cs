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

    private Speaker[] _speakers = {Speaker.Enemy, Speaker.Character};
    private int _speakerIdx = 0;
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

    public void OnClick() 
    {
        Debug.Log("Click");

        UIDialogHistory hist = GameObject.FindObjectOfType<UIDialogHistory>();
        hist.AddPhrase(_speakers[_speakerIdx % 2], "foooo");
        _speakerIdx += 1;

        UIDeck deck = GameObject.FindObjectOfType<UIDeck>();
        // deck.AddCard("mental_breakdown", "Can't a guy have a mental breakdown in private?");
    }
}
