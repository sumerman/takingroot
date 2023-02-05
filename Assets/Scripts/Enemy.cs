using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public CharacterType characterType;
    int victories = 0;

    public Enemy(CharacterType characterType)
    {
        this.characterType = characterType;
    }

    public Reply ApplyCard(Card card)
    {
        if (card.cardType != CardType.Argument)
        {
            throw new System.Exception("Card type isn't an Argument");
        }
        
        Reply reply = characterType.ReplyToCard(card.id);
        if (reply.effect == Effect.Positive)
        {
            victories++;
        }

        return reply;
    }

    public bool Defeated
    {
        get { return victories >= characterType.victoriesRequired; }
    }
}
