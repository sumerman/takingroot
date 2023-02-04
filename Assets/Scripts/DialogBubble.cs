using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class DialogBubble : MonoBehaviour
{
    public string Text
    {
        get => _text;
        set { _text = value; ForceUpdate(); }
    }
    [SerializeField]
    private string _text;

    private TextMeshProUGUI textComponent;

    // Start is called before the first frame update
    void Start()
    {
        ForceUpdate();
    }

    void ForceUpdate() 
    {
        textComponent = GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        Assert.IsNotNull(textComponent);
        textComponent.text = _text;
        textComponent.ForceMeshUpdate(true, true);
    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
        ForceUpdate();
        #endif
    }
}
