using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Effect
{
    Negative = 0,
    Positive = 1
}

public struct Reply
{
    public Effect Effect { get; }
    public string Text { get; }

    public Reply(Effect effect, string text)
    {
        Effect = effect;
        Text = text;
    }
}

[System.Serializable]
public class Nature
{
    private string title;
    Dictionary<int, Reply> cardReplies;

    public string Title { get; }

    public Reply ReplyToCard(int cardId)
    {
        return cardReplies[cardId];
    }

    public static Nature CreateFromJson(string jsonString)
    {
        return JsonUtility.FromJson<Nature>(jsonString);
    }
}
