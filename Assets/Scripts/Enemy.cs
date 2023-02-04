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

    // string ApplyCard(Card card)
    // {
    //     // nature.Effect(card.id);
    // }
}
