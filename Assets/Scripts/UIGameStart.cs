using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameStart : MonoBehaviour
{
	public Button uiStart;
	public GameController gameController;
	void Start()
	{
		if (uiStart)
		{
			uiStart.onClick.AddListener(OnStartClick);
		}
	}

	void OnStartClick()
	{
        if (gameController) {
            gameController.NewGame();
        }
        SceneManager.LoadScene(GameController.SCENE_GAME);
	}

	void Update()
	{

	}
}
