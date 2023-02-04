using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
    Family = 1,
    Friend = 2,
    ThirdParty = 3
}

public class Enemy : MonoBehaviour
{
    CharacterType characterType;
    Nature nature;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void ApplyCard(Card card)
    {
        if (card.CardType != CardType.Argument)
        {
            throw new System.Exception("Card type isn't an Argument");
        }
        Reply reply = nature.ReplyToCard(card.Id);
        // TODO: render `reply.Text` in a dialog box
        // TODO: conditional logic on `reply.Effect`
    }
}
