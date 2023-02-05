using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public static GameController singletone = null;
	public const string SCENE_GAME = "Game";

	[SerializeField] public Enemy currentEnemy;
	[SerializeField] public Hand hand;
	[SerializeField] public Deck deck;

	public TextAsset characterTypesJson;
	public TextAsset cardsJson;

    
    CharacterTypes characterTypes;
    private int round = 1;

	void Awake()
	{
		DontDestroyOnLoad(this);
		if (singletone == null)
		{
			singletone = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	void Start()
	{
		LoadResources();
		NewGame();
	}
    public void NewGame() 
    {
        round = 0;
        CharacterType characterType = characterTypes.GetCharacterType(round);
        currentEnemy = new Enemy(characterType);
        deck = Deck.GenerateSafeDeck(characterType);
        hand = new Hand(deck);
        SceneManager.LoadScene(GameController.SCENE_GAME);
    }

	public void OnGameSceneStart(UIGameSceneController sceneController)
	{
		// TODO
		sceneController.overgrowth = round;
        // sceneController.enemy.CurretAvatar = currentEnemy.
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
        deck = Deck.ShuffleNewDeck();
    }
}
