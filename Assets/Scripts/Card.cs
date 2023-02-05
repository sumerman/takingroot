using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType {
    Argument = 1,
    Action = 2
}

public struct ResolvedCard {
    Reply reply;
    List<Card> cards;
    bool defeated;

    public ResolvedCard(Reply reply, List<Card> cards, bool defeated)
    {
        this.reply = reply;
        this.cards = cards;
        this.defeated = defeated;
    }

    public Reply Reply { get => reply; }
    public List<Card> Cards { get => cards; }
    public bool Defeated { get => defeated; }
}

[System.Serializable]
public class AvailableCards
{
    public List<Card> cards;

    public Card GetCard(int cardId)
    {
        return cards.Find((r) => r.id == cardId);
    }
}

[System.Serializable]
public class Card
{
    public string title;
    public int id;
    public string spriteName;
    public CardType cardType;

    public ResolvedCard Play(Hand hand, Enemy enemy)
    {
        hand.WithdrawCard(this);
        if(this.cardType == CardType.Argument)
        {
            Reply reply = enemy.ApplyCard(this);

            return new ResolvedCard(reply, null, enemy.Defeated);
        }
        else if(this.cardType == CardType.Action)
        {
            List<Card> cards = hand.ApplyCard(this);

            return new ResolvedCard(null, cards, false);
        }
        else
        {
            throw new System.Exception("wrong card type");
        }
    }
}
