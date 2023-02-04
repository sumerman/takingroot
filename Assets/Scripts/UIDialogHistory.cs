using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class UIDialogHistory : MonoBehaviour
{
    private LayoutGroup _layoutGroup;
    public GameObject dialogBubblePrefab;
    void Start()
    {
        _layoutGroup = GetComponent<LayoutGroup>();
        Assert.IsNotNull(_layoutGroup); 
        Clear();
    }

    public void Clear() 
    {
        while(transform.childCount > 0) {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }

    public void AddPhrase(string text)
    {
        GameObject newPhrase = Instantiate(dialogBubblePrefab, transform.position, Quaternion.identity);
        newPhrase.transform.SetParent(transform, false);
        UIDialogBubble dialogBubble = newPhrase.GetComponent<UIDialogBubble>();
        if (dialogBubble) {
            dialogBubble.Text = text;
        }
    }

    void Update()
    {
        
    }
}
