using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class UIActionCard : MonoBehaviour
{
    public Image cardImage;
    public string text
    {
        get => _text;
        set { _text = value; ForceUpdate(); }
    }
    [SerializeField]
    private string _text;

    public Sprite cardSprite
    {
        get => _cardSprite;
        set { _cardSprite = value; ForceUpdate(); }
    }
    [SerializeField]
    private Sprite _cardSprite;
    private Image _backgroundImage;
    private TextMeshProUGUI _textComponent;
    // Start is called before the first frame update
    void Start()
    {
        ForceUpdate();
    }

    public void ForceUpdate() 
    {
        _textComponent = GetComponentInChildren<TextMeshProUGUI>();
        _backgroundImage = GetComponentInChildren<Image>();
        Assert.IsNotNull(_textComponent);
        Assert.IsNotNull(_backgroundImage);
        _textComponent.text = _text;
        _textComponent.ForceMeshUpdate(true, true);
        cardImage.sprite = _cardSprite;
    }
    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
        ForceUpdate();
        #endif
    }
}
