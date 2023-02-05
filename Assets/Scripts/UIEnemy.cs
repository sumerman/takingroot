using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.UI;
using UnityEngine.Assertions;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class UIEnemy : MonoBehaviour
{
    public Sprite[] avatarSprites;
    public UnityEvent onAnimationFinish;
    public UnityEvent onAnimationLeaveFinish;
    public Image avatarImage;

    public string CurretAvatar
    {
        get => _currentAvatar;
        set
        {
            _currentAvatar = value;
            ForceUpdate();
        }
    }
    [SerializeField]
    public string _currentAvatar;
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnAnimationFinish() {
        onAnimationFinish.Invoke();
    }
    void OnAnimationLeaveFinish() {
        onAnimationLeaveFinish.Invoke();
    }
    void ForceUpdate()
    {
        if (avatarImage == null || avatarSprites == null || avatarSprites.Length == 0)
            return;
        for (int i = 0; i < avatarSprites.Length; i++)
        {
            if (avatarSprites[i].name.ToLower() == _currentAvatar.ToLower()) {
                avatarImage.sprite = avatarSprites[i];
                break;
            }
        }
    }

    public void MakeLeave() {
        Animator anim = GetComponent<Animator>();
        anim.Play("Leave", -1, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        ForceUpdate();
#endif
    }
}