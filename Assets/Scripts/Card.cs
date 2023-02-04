using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType {
    Argument = 1,
    Action = 2
}

public class Card : MonoBehaviour
{
    [SerializeField] string title;
    [SerializeField] string description;
    [SerializeField] public int Id { get; }
    [SerializeField] string spriteId;
    [SerializeField] public CardType CardType { get; }
    [SerializeField] GameController controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Play()
    {
        Hand hand = controller.hand;
        if(this.CardType == CardType.Argument)
        {
            Enemy enemy = controller.currentEnemy;
            enemy.ApplyCard(this);
        }
        else if(this.CardType == CardType.Action)
        {
            hand.ApplyCard(this);
        }
        hand.WithdrawCard(this);
    }
}
