using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Effect
{
    Negative = 0,
    Positive = 1
}

[System.Serializable]
public class Nature
{
    List<int> positiveCardsIds;
    List<int> negativeCardsIds;
    private string title;

    public string Title { get => title; set => title = value; }

    public Effect CardEffect(int cardId)
    {
        if (positiveCardsIds.Contains(cardId))
        {
            return Effect.Positive;
        }
        else if (negativeCardsIds.Contains(cardId))
        {
            return Effect.Negative;
        }
        else
        {
            throw new System.Exception("Undefined card id");
        }
    }

    public static Nature CreateFromJson(string jsonString)
    {
        return JsonUtility.FromJson<Nature>(jsonString);
    }
}
