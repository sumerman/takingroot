using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionCards
{
    Rootstagram = 13,
    News = 14,
    Meme = 15
}

public class Hand : MonoBehaviour
{
    List<Card> cards;
    GameController controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyCard(Card card)
    {
        switch((ActionCards) card.Id)
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

    public void WithdrawCard(Card card)
    {
        cards.Remove(card);
    }

    public void DrawNewCard()
    {
        Deck deck = controller.deck;
        if (deck.CanDrawCard())
        {
            cards.Add(deck.DrawNewCard());
        }
        else
        {
            // TODO render empty hand notification
        }
    }

    void AddCardById(int id)
    {
        // Card card = Card.CreateById(id)
        Card card = null; // TODO replace
        cards.Add(card);
    }
}
