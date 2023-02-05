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

    public ResolvedCard(Reply reply, List<Card> cards)
    {
        this.reply = reply;
        this.cards = cards;
    }

    public Reply Reply { get => reply; }
    public List<Card> Cards { get => cards; }
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
    public CardType CardType { get; }
    public GameController controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ResolvedCard Play()
    {
        Hand hand = controller.hand;
        hand.WithdrawCard(this);
        if(this.CardType == CardType.Argument)
        {
            Enemy enemy = controller.currentEnemy;
            Reply reply = enemy.ApplyCard(this);

            return new ResolvedCard(reply, null);
        }
        else if(this.CardType == CardType.Action)
        {
            List<Card> cards = hand.ApplyCard(this);

            return new ResolvedCard(null, cards);
        }
        else
        {
            throw new System.Exception("wrong card type");
        }
    }
}
