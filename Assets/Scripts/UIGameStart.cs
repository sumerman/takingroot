using UnityEngine;
using UnityEngine.UI;

public class UIGameStart : MonoBehaviour
{
	public Button uiStart;
	void Start()
	{
		if (uiStart)
		{
			uiStart.onClick.AddListener(OnStartClick);
		}
	}

	void OnStartClick()
	{
        
		GameController gameController = FindObjectOfType<GameController>();
		if (gameController)
		{
			gameController.NewGame();
		}
	}

	void Update()
	{

	}
}
