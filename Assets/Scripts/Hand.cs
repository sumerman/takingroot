using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }

    public void WithdrawCard(Card card)
    {
        cards.Remove(card);
    }

    void DrawNewCard()
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
}
