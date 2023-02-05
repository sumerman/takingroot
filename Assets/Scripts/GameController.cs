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
	public const string SCENE_OVER = "Game Over";
	public const string SCENE_MAIN = "Main";

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
		InitRound();
		if (SceneManager.GetActiveScene().name != GameController.SCENE_GAME)
		{
			SceneManager.LoadScene(GameController.SCENE_GAME);
		}
	}

	public void OnGameSceneStart(UIGameSceneController sceneController)
	{
		Assert.IsNotNull(sceneController);
		_currentSceneController = sceneController;
		_currentSceneController.overgrowth = round - 1;
		_currentSceneController.enemy.CurretAvatar = currentEnemy.characterType.title;
		_currentSceneController.hand.Clear();
		for (int i = 0; i < Deck.defaultHandSize; i++)
		{
			Card c = hand.DrawNewCard();
			Assert.IsNotNull(c); // due to the loop condition
			_currentSceneController.hand.AddCard(c.spriteName, c.title, () => this.gameObject.SendMessage("PlayCard", c));
		}
		_currentSceneController.dialog.Clear();
	}

	public void PlayCard(Card c)
	{
		Debug.Log("PlayCard!");
		_currentSceneController.dialog.AddPhrase(Speaker.Character, c.title);
		ResolvedCard res = c.Play(hand, currentEnemy);
		if (res.Reply != null)
		{
			_currentSceneController.dialog.AddPhrase(Speaker.Enemy, res.Reply.text);
		}
		else if (res.Cards != null)
		{
			res.Cards.ForEach((Card drawnCard) =>
			{
				_currentSceneController.hand.AddCard(drawnCard.spriteName, drawnCard.title, () =>
				{
					this.gameObject.SendMessage("PlayCard", drawnCard);
				});
			});
		}
		if (res.Defeated)
		{
			StartNextRound(_currentSceneController);
		}
		else if (hand.IsEmpty())
		{
			SceneManager.LoadScene(GameController.SCENE_GAME);
		}
	}

	public void OnEnemyEntrance()
	{
		_currentSceneController.dialog.AddPhrase(Speaker.Enemy, currentEnemy.characterType.intro);
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

	private void InitRound()
	{
		CharacterType characterType = characterTypes.GetCharacterType(round);
		Assert.IsNotNull(characterType);
		currentEnemy = new Enemy(characterType);
		deck = Deck.GenerateSafeDeck(characterType);
		hand = new Hand(deck);
	}

	private void StartNextRound(UIGameSceneController sceneController)
	{
		if (round < 4)
		{
			round++;

			InitRound();

			// TODO
			SceneManager.LoadScene(GameController.SCENE_GAME);
		} 
        else 
        {
			// TODO
			SceneManager.LoadScene(GameController.SCENE_MAIN);
        }
	}
}
