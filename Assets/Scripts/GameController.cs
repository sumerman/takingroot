using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public const string SCENE_GAME = "Game";
    public const string SCENE_OVER = "Game Over";
    public const string SCENE_MAIN = "Main";
    public const int MAX_ROUNDS = 4;

    [SerializeField] private UIEnemy uiEnemy;
    [SerializeField] private UIDialogHistory dialog;
    [SerializeField] private UIDeck uiHand;
    [SerializeField] private UIOvergrowth background;
    [SerializeField] private UIOvergrowth characterPortrait;

    private Enemy currentEnemy;
    private Hand hand;

    public int Round
    {
        get => PlayerState.Instance.round;
        set => PlayerState.Instance.round = value;
    }

    private Deck Deck
    {
        get => PlayerState.Instance.deck;
        set => PlayerState.Instance.deck = value;
    }

    void Awake()
    {
        Assert.IsNotNull(uiEnemy);
        Assert.IsNotNull(uiHand);
        Assert.IsNotNull(dialog);
        Assert.IsNotNull(background);
        Assert.IsNotNull(characterPortrait);

        uiEnemy.onAnimationFinish.AddListener(OnEnemyEntrance);
        uiEnemy.onAnimationLeaveFinish.AddListener(OnEnemyLeave);
    }

    void Start()
    {
        InitRound();

        uiEnemy.CurretAvatar = currentEnemy.characterType.title;
        dialog.Clear();
        uiHand.Clear();

        if (Round > MAX_ROUNDS)
        {
            Destroy(uiEnemy.gameObject);
        }
        else
        {
            for (int i = 0; i < Deck.defaultHandSize; i++)
            {
                Card c = hand.DrawNewCard();
                Assert.IsNotNull(c); // due to the loop condition
                uiHand.AddCard(c.spriteName, c.title, () => this.gameObject.SendMessage("PlayCard", c));
            }
        }

    }

    void Update()
    {
        background.currentStage = Round - 1;
        characterPortrait.currentStage = Round - 1;
    }

    public static void NewGame()
    {
        PlayerState.Instance.round = 1;
        if (SceneManager.GetActiveScene().name != GameController.SCENE_GAME)
        {
            SceneManager.LoadScene(GameController.SCENE_GAME);
        }
    }


    public void PlayCard(Card c)
    {
        Debug.Log("PlayCard!");
        dialog.AddPhrase(Speaker.Character, c.title);
        ResolvedCard res = c.Play(hand, currentEnemy);
        if (res.Reply != null)
        {
            dialog.AddPhrase(Speaker.Enemy, res.Reply.text);
        }
        else if (res.Cards != null)
        {
            res.Cards.ForEach((Card drawnCard) =>
            {
                uiHand.AddCard(drawnCard.spriteName, drawnCard.title, () =>
            {
                this.gameObject.SendMessage("PlayCard", drawnCard);
            });
            });
        }
        if (res.Defeated)
        {
            uiEnemy.MakeLeave();
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
        dialog.AddPhrase(Speaker.Enemy, currentEnemy.characterType.intro);
    }
    public void OnEnemyLeave()
    {
        StartNextRound();
    }

    private void InitRound()
    {
        CharacterType characterType = PlayerState.Instance.GetCurrentCharacterType();
        Assert.IsNotNull(characterType);
        currentEnemy = new Enemy(characterType);
        if (Round == 1)
        {
            Deck = Deck.GenerateSafeDeck(characterType);
        }
        else
        {
            Deck.SimulateDeckBuilding();
            Deck = Deck.ShuffleNewDeck();
        }
        hand = new Hand(Deck);
    }

    private void StartNextRound()
    {
        if (Round < MAX_ROUNDS)
        {
            Round++;
            // TODO a deck building scene
            SceneManager.LoadScene(GameController.SCENE_GAME);
        }
        else
        {
            // TODO a proper win scene; 
            // until then misuse the overgrowth setting (derived from round on load)
            Round++;
            SceneManager.LoadScene(GameController.SCENE_GAME);
        }
    }
}
