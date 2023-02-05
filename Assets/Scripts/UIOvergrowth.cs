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

    public int currentStage;
    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        currentStage = 0;
        Assert.IsNotNull(_image);
    }

    // Update is called once per frame
    void Update()
    {
        if (stageSprites == null)
            return;
        int stagesAvailable = stageSprites.Length;
        if (stagesAvailable > 0)
        {
            _image.sprite = stageSprites[Mathf.Max(0, currentStage) % stagesAvailable];
        }
    }
}
