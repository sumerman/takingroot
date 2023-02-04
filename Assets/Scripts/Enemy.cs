using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    CharacterType characterType;
    int victories = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Enemy(CharacterType characterType)
    {
        this.characterType = characterType;
    }

    public void ApplyCard(Card card)
    {
        if (card.CardType != CardType.Argument)
        {
            throw new System.Exception("Card type isn't an Argument");
        }
        
        Reply reply = characterType.ReplyToCard(card.Id);
        if (reply.effect == Effect.Positive)
        {
            victories++;
        }
        // TODO: render `reply.Text` in a dialog box
        // TODO: conditional logic on `reply.Effect`
    }

    public bool Defeated
    {
        get { return victories >= characterType.victoriesRequired; }
    }
}
