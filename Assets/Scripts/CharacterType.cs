using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CharacterTypes
{
    public List<CharacterType> items;

    public CharacterType GetCharacterType(int typeId)
    {
        return items.Find(i => i.id == typeId);
    }
}

[System.Serializable]
public class CharacterType
{
    public int id;
    public string title;
    public string intro;
    public string outro;
    public List<Nature> natures;
    Nature selectedNature;
    public int victoriesRequired;

    public Nature SelectedNature
    {
        get {
            if (selectedNature == null)
            {
                selectedNature = natures[Random.Range(0, natures.Count - 1)];
            }
            return selectedNature;
        }
    }

    public Reply ReplyToCard(int cardId)
    {
        return SelectedNature.GetReply(cardId);
    }
}
