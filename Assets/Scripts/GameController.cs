using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameController : MonoBehaviour
{
    public const string SCENE_GAME = "Game";

    [SerializeField] public Enemy currentEnemy;
    [SerializeField] public Hand hand;
    [SerializeField] public Deck deck;

    public TextAsset characterTypesJson;
    public TextAsset cardsJson;

    
    CharacterTypes characterTypes;
    private int round = 1;

    public int Round { get => round; set => round = value; }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        LoadResources();
        NewGame();
    }

    public void NewGame() 
    {
        CharacterType characterType = characterTypes.GetCharacterType(round);
        currentEnemy = new Enemy(characterType);
        deck = Deck.GenerateSafeDeck(characterType);
        hand = new Hand(deck);
    }

    public void OnGameSceneStart(UIGameSceneController sceneController) 
    {
        // TODO
        sceneController.overgrowth = 0;
    }

    public void OnEnemyEntrance() 
    {
        // TODO
    }

    void Update()
    {
        
    }

    void LoadResources()
    {
        characterTypes = JsonUtility.FromJson<CharacterTypes>(characterTypesJson.text);
        Deck.availableCards = JsonUtility.FromJson<AvailableCards>(cardsJson.text);
    }

    private void StartNextRound(UIGameSceneController sceneController)
    {
        round++;
        sceneController.overgrowth = round - 1;
        CharacterType characterType = characterTypes.GetCharacterType(round);
    }
}
