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
    [SerializeField] Sprite art;
    [SerializeField] public CardType CardType { get; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
