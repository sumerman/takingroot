using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class DialogHistory : MonoBehaviour
{
    // Start is called before the first frame update
    private LayoutGroup layoutGroup;
    public GameObject dialogBubblePrefab;
    void Start()
    {
        layoutGroup = GetComponent<LayoutGroup>();
        Assert.IsNotNull(layoutGroup); 
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
        DialogBubble dialogBubble = newPhrase.GetComponent<DialogBubble>();
        if (dialogBubble) {
            dialogBubble.Text = text;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
