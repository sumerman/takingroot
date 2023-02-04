using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    CharacterType characterType;

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
        // TODO: render `reply.Text` in a dialog box
        // TODO: conditional logic on `reply.Effect`
    }
}
