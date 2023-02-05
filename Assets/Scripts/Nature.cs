using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Effect
{
    Negative = 0,
    Positive = 1
}

[System.Serializable]
public struct Reply
{
    public Effect effect;
    public string text;
    public int cardId;
}

[System.Serializable]
public class Nature
{
    public int id;
    public List<Reply> replies;

    public List<int> VictoryCardIds()
    {
        List<Reply> victoryReplies = replies.FindAll(r => r.effect == Effect.Positive);
        return victoryReplies.ConvertAll<int>(reply => reply.cardId);
    }

    public Reply GetReply(int cardId)
    {
        return replies.Find(r => r.cardId == cardId);
    }
}
