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

public class EnemyClassification
{
    Dictionary<int, Reply> cardReplies;

    public Dictionary<int, Reply> CardReplies { get => cardReplies; }

    public static EnemyClassification CreateFromJson(string jsonString)
    {
        return JsonUtility.FromJson<Nature>(jsonString);
    }
}
