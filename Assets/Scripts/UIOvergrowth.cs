using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

#if UNITY_EDITOR
using UnityEditor;
#endif
[ExecuteInEditMode]
public class UIOvergrowth : MonoBehaviour
{
    public Sprite[] stageSprites;
    private Image _image;

    public int CurretStage
    {
        get => _currentStage;
        set
        {
            _currentStage = Mathf.Max(0, value);
            ForceUpdate();
        }
    }
    [SerializeField]
    public int _currentStage = 0;
    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        Assert.IsNotNull(_image);
    }

    void ForceUpdate()
    {
        if (stageSprites == null)
            return;
        int stagesAvailable = stageSprites.Length;
        if (stagesAvailable > 0)
        {
            _image.sprite = stageSprites[_currentStage % stagesAvailable];
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
