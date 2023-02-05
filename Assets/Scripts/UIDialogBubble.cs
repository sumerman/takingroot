using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
#if UNITY_EDITOR
using UnityEditor;
#endif

public enum Speaker
{
	Character = 0,
	Enemy = 1
}

[ExecuteInEditMode]
public class UIDialogBubble : MonoBehaviour
{
	public string text
	{
		get => _text;
		set { _text = value; ForceUpdate(); }
	}
	[SerializeField]
	private string _text;

	public Speaker speaker
	{
		get => _speaker;
		set { _speaker = value; ForceUpdate(); }
	}
	[SerializeField]
	private Speaker _speaker;

	public Sprite charSpeaker;
	public Sprite enemySpeaker;
	private TextMeshProUGUI _textComponent;
	private Image _image;

	// Start is called before the first frame update
	void Start()
	{
		ForceUpdate();
	}

	public void ForceUpdate()
	{
		_textComponent = GetComponentInChildren<TextMeshProUGUI>();
		Assert.IsNotNull(_textComponent);
		_image = GetComponentInChildren<Image>();
		Assert.IsNotNull(_textComponent);

		_textComponent.text = _text;
		_textComponent.ForceMeshUpdate(true, true);

		if (_speaker == Speaker.Character)
		{
			_image.sprite = charSpeaker;
		}
		else if (_speaker == Speaker.Enemy)
		{
			_image.sprite = enemySpeaker;
		}
	}

	// Update is called once per frame
	void Update()
	{
#if UNITY_EDITOR
		ForceUpdate();
#endif
	}
}
