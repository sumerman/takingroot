using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameController : MonoBehaviour
{
    [SerializeField] public Enemy currentEnemy;
    [SerializeField] public Hand hand;
    [SerializeField] public Deck deck;

    public TextAsset characterTypesJson;
    public TextAsset cardsJson;

    
    CharacterTypes characterTypes;
    AvailableCards availableCards;

    // Start is called before the first frame update
    void Start()
    {
        LoadResources();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadResources()
    {
        characterTypes = JsonUtility.FromJson<CharacterTypes>(characterTypesJson.text);
        availableCards = JsonUtility.FromJson<AvailableCards>(cardsJson.text);
    }

}
