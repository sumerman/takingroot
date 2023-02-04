using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class UIDeck : MonoBehaviour
{
    private LayoutGroup _layoutGroup;
    public GameObject actionCardPrefab;
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

    public void AddCard(Sprite sprite, string text)
    {
        GameObject newCard = Instantiate(actionCardPrefab, transform.position, Quaternion.identity);
        newCard.transform.SetParent(transform, false);
        UIActionCard uiCard = newCard.GetComponent<UIActionCard>();
        if (uiCard) {
            uiCard.Text = text;
            uiCard.CardSprite = sprite;
        }
    }

    void Update()
    {
        
    }
}
