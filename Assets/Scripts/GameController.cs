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

    
    CharacterTypes characterTypes;

    // Start is called before the first frame update
    void Start()
    {
        LoadResources();
        Debug.Log(characterTypes.items[0].title);
        Debug.Log(characterTypes.items[0].SelectedNature.replies[0].text);
        Debug.Log(characterTypes.items[0].SelectedNature.replies[0].effect);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadResources()
    {
        characterTypes = JsonUtility.FromJson<CharacterTypes>(characterTypesJson.text);
    }

}
