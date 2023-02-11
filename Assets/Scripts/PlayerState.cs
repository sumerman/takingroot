using UnityEngine;

public class PlayerState
{
    public CharacterTypes characterTypes;
    public int round = 1;
    public Deck deck;

    private static PlayerState _instance;

    public static PlayerState Instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }
            _instance = new PlayerState();
            _instance.LoadResources();
            return _instance;
        }
    }

    public CharacterType GetCurrentCharacterType()
    {
        return characterTypes.GetCharacterType(round);
    }

    private void LoadResources()
    {
        TextAsset characterTypesJson = Resources.Load<TextAsset>("character_types");
        TextAsset cardsJson = Resources.Load<TextAsset>("cards");
        characterTypes = JsonUtility.FromJson<CharacterTypes>(characterTypesJson.text);
        Deck.availableCards = JsonUtility.FromJson<AvailableCards>(cardsJson.text);
        Debug.Log("Resources loaded.");
    }

}