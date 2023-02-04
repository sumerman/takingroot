using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void ApplyCard(Card card)
    {
        if (card.CardType != CardType.Argument)
        {
            throw new System.Exception("Card type isn't an Argument");
        }
        Reply reply = ReplyToCard(card.Id);
        // TODO: render `reply.Text` in a dialog box
        // TODO: conditional logic on `reply.Effect`
    }
    private Reply ReplyToCard(int cardId)
    {
        if (nature.CardReplies.ContainsKey(cardId))
        {
            return nature.CardReplies[cardId];
        }
        else
        {
            return characterType.CardReplies[cardId];
        }
    }
}
