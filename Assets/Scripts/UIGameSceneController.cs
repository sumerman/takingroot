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
  
    void Awake() {
		Assert.IsNotNull(enemy);
		enemy.onAnimationFinish.AddListener(OnEnemyEntrance);
    }
	void Start()
	{
		GameController gc = FindObjectOfType<GameController>();
		if (gc == null)
        {
            GameObject gcObj = new GameObject("TestGameController", typeof(GameController));
            gc = gcObj.GetComponent<GameController>();
            gc.NewGame();
        }
        gc.OnGameSceneStart(this);
	}

	void OnEnemyEntrance()
	{
        Debug.Log("Enemy Entrance.");
		GameController gc = FindObjectOfType<GameController>();
		if (gc)
		{
            gc.OnEnemyEntrance();
		}
	}

	void Update()
	{
        if (background) background.currentStage = overgrowth;
        if (character) character.currentStage = overgrowth;
	}
}
