using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class UIGameSceneController : MonoBehaviour
{
	public UIEnemy enemy;
	public UIDialogHistory dialog;
	public UIDeck hand;
	public UIOvergrowth background;
	public UIOvergrowth character;

	public int overgrowth;
  
    private GameController _gc;

    void Awake() {
		Assert.IsNotNull(enemy);
		enemy.onAnimationFinish.AddListener(OnEnemyEntrance);
    }
	void Start()
	{
		GameController _gc = FindObjectOfType<GameController>();
		if (_gc == null)
        {
            GameObject gcObj = new GameObject("TestGameController", typeof(GameController));
            _gc = gcObj.GetComponent<GameController>();
            _gc.NewGame();
        }
        _gc.OnGameSceneStart(this);
	}

	void OnEnemyEntrance()
	{
		if (_gc)
		{
            _gc.OnEnemyEntrance();
		}
	}

	void Update()
	{
        if (background) background.currentStage = overgrowth;
        if (character) character.currentStage = overgrowth;
	}
}
