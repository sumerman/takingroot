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
	public const int MAX_ROUNDS = 4;

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

		_currentSceneController.dialog.Clear();
		_currentSceneController.hand.Clear();

		if (round > MAX_ROUNDS)
		{
			Destroy(_currentSceneController.enemy.gameObject);
		}
		else
		{
			for (int i = 0; i < Deck.defaultHandSize; i++)
			{
				Card c = hand.DrawNewCard();
				Assert.IsNotNull(c); // due to the loop condition
				_currentSceneController.hand.AddCard(c.spriteName, c.title, () => this.gameObject.SendMessage("PlayCard", c));
			}
		}

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
            _currentSceneController.enemy.MakeLeave();
		}
		else if (hand.IsEmpty())
		{
			StartCoroutine(GameOver());
		}
	}

	private IEnumerator GameOver()
	{
		yield return new WaitForSeconds(1.0f);
		SceneManager.LoadScene(GameController.SCENE_OVER);
	}

	public void OnEnemyEntrance()
	{
		_currentSceneController.dialog.AddPhrase(Speaker.Enemy, currentEnemy.characterType.intro);
	}
	public void OnEnemyLeave() 
    {
        StartNextRound(_currentSceneController);
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
		if (round == 1)
		{
            deck = Deck.GenerateSafeDeck(characterType);
		}
		else
		{
			Deck.SimulateDeckBuilding();
			deck = Deck.ShuffleNewDeck();
		}
		hand = new Hand(deck);
	}

	private void StartNextRound(UIGameSceneController sceneController)
	{
		if (round < MAX_ROUNDS)
		{
			round++;

			InitRound();

			// TODO
			SceneManager.LoadScene(GameController.SCENE_GAME);
		}
		else
		{
			round++;
			SceneManager.LoadScene(GameController.SCENE_GAME);
			// TODO
			// SceneManager.LoadScene(GameController.SCENE_MAIN);
		}
	}
}
