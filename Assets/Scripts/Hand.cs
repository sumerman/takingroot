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
    }

    public List<Card> ApplyCard(Card card)
    {
        List<Card> newCards = new List<Card>();
        switch((ActionCards) card.id)
        {
            case ActionCards.Rootstagram:
                newCards.Add(DrawNewCard());
                newCards.Add(AddCardById((int) ActionCards.Meme));
                break;
            case ActionCards.News:
                newCards.Add(DrawNewCard());
                newCards.Add(DrawNewCard());
                break;
            case ActionCards.Meme:
                break;
        }

        return newCards;
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
        Card card = Deck.availableCards.GetCard(id);
        cards.Add(card);

        return card;
    }
}
