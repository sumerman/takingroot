using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public static GameController singletone = null;
	public const string SCENE_GAME = "Game";

	[SerializeField] public Enemy currentEnemy;
	[SerializeField] public Hand hand;
	[SerializeField] public Deck deck;

	CharacterTypes characterTypes;
	private int round = 1;

	private UIGameSceneController _currentSceneController = null;

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
            return;
		}
        LoadResources();
	}

	void Start()
	{
	}

	public void NewGame()
	{
		round = 1;
		CharacterType characterType = characterTypes.GetCharacterType(round);
        Assert.IsNotNull(characterType);
		currentEnemy = new Enemy(characterType);
		deck = Deck.GenerateSafeDeck(characterType);
		hand = new Hand(deck);
        if (SceneManager.GetActiveScene().name != GameController.SCENE_GAME) {
            SceneManager.LoadScene(GameController.SCENE_GAME);
        }
	}

	public void OnGameSceneStart(UIGameSceneController sceneController)
	{
        Assert.IsNotNull(sceneController);
		_currentSceneController = sceneController;
		_currentSceneController.overgrowth = round;
		_currentSceneController.enemy.CurretAvatar = currentEnemy.characterType.title;
        _currentSceneController.hand.Clear();
		for (int i = 0; i < Deck.defaultHandSize; i++)
		{
			Card c = hand.DrawNewCard();
			Assert.IsNotNull(c); // due to the loop condition
			_currentSceneController.hand.AddCard(c.spriteName, c.title);
		}
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
        TextAsset characterTypesJson = Resources.Load<TextAsset>("character_types");
        TextAsset cardsJson = Resources.Load<TextAsset>("cards");
		characterTypes = JsonUtility.FromJson<CharacterTypes>(characterTypesJson.text);
		Deck.availableCards = JsonUtility.FromJson<AvailableCards>(cardsJson.text);
        Debug.Log("Resources loaded.");
	}

	private void StartNextRound(UIGameSceneController sceneController)
	{
		round++;
		sceneController.overgrowth = round - 1;
		CharacterType characterType = characterTypes.GetCharacterType(round);
		deck = Deck.ShuffleNewDeck();
	}
}
