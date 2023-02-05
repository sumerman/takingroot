using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
#if UNITY_EDITOR
using UnityEditor;
#endif

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

    private TextMeshProUGUI _textComponent;

    // Start is called before the first frame update
    void Start()
    {
        ForceUpdate();
    }

    public void ForceUpdate() 
    {
        _textComponent = GetComponentInChildren<TextMeshProUGUI>();
        Assert.IsNotNull(_textComponent);
        _textComponent.text = _text;
        _textComponent.ForceMeshUpdate(true, true);
    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
        ForceUpdate();
        #endif
    }
}
