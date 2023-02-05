using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionCards
{
    Rootstagram = 13,
    News = 14,
    Meme = 15
}

public class Hand
{
    List<Card> cards = new List<Card>();
    Deck deck;

    public Hand(Deck deck)
    {
        this.deck = deck;
        for (int i = 0; i < Deck.defaultHandSize; i++)
        {
            DrawNewCard();
        }
    }

    public void ApplyCard(Card card)
    {
        switch((ActionCards) card.id)
        {
            case ActionCards.Rootstagram:
                DrawNewCard();
                AddCardById((int) ActionCards.Meme);
                break;
            case ActionCards.News:
                DrawNewCard();
                DrawNewCard();
                break;
            case ActionCards.Meme:
                break;
        }
    }

    public Card WithdrawCard(Card card)
    {
        cards.Remove(card);

        return card;
    }

    public Card DrawNewCard()
    {
        if (deck.CanDrawCard())
        {
            Card newCard = deck.DrawNewCard();
            cards.Add(newCard);

            return newCard;
        }
        else
        {
            return null;
        }
    }

    Card AddCardById(int id)
    {
        Card card = GameController.availableCards.GetCard(id);
        cards.Add(card);

        return card;
    }
}
