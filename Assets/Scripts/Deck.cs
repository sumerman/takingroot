using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    Queue<Card> cards;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Size
    {
        get { return cards.Count; }
    }

    public bool CanDrawCard()
    {
        return (Size > 0);
    }

    public Card DrawNewCard()
    {
        return cards.Dequeue();
    }
}
