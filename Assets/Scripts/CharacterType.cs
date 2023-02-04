using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CharacterTypes
{
    Family = 1,
    Friend = 2,
    ThirdParty = 3
}

[System.Serializable]
public class CharacterType : EnemyClassification
{
    CharacterTypes type;
}
