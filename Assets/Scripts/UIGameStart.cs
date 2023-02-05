using UnityEngine;
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
	}

	void Update()
	{

	}
}
