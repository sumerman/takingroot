using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Nature
{
    List<int> positiveCardsIds;
    List<int> negativeCardsIds;
    private string title;

    public string Title { get => title; set => title = value; }

    public bool Effect(int cardId)
    {
        if (positiveCardsIds.Contains(cardId))
        {
            return true;
        }
        else if (negativeCardsIds.Contains(cardId))
        {
            return false;
        }
        else
        {
            throw new System.Exception("Undefined card id");
        }
    }
}
