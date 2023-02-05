using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class UIDeck : MonoBehaviour
{
	private LayoutGroup _layoutGroup;
	public GameObject actionCardPrefab;
	public Sprite[] cardSprites;

	private Dictionary<string, Sprite> _cardSprites;
	private int backgroundIndex = 0;

	void Start()
	{
		_layoutGroup = GetComponent<LayoutGroup>();
		Assert.IsNotNull(_layoutGroup);

		_cardSprites = new Dictionary<string, Sprite>();
		if (cardSprites == null || cardSprites.Length == 0)
			return;
		for (int i = 0; i < cardSprites.Length; i++)
		{
			_cardSprites.Add(cardSprites[i].name.ToLower(), cardSprites[i]);
		}

		Clear();
	}

	public void Clear()
	{
		while (transform.childCount > 0)
		{
			DestroyImmediate(transform.GetChild(0).gameObject);
		}
	}

	public void AddCard(string spriteName, string text)
	{
		GameObject newCard = Instantiate(actionCardPrefab, Vector3.one, Quaternion.identity);
		newCard.transform.SetParent(transform, false);
		UIActionCard uiCard = newCard.GetComponent<UIActionCard>();
		if (uiCard)
		{
			uiCard.text = text;
			if (_cardSprites.ContainsKey(spriteName))
			{
				uiCard.cardSprite = _cardSprites[spriteName];
				uiCard.backgroundIndex = backgroundIndex;
				backgroundIndex++;
			}
		}
	}

	void Update()
	{

	}
}
