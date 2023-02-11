using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
	[SerializeField] private Button restartButton;
	[SerializeField] private AudioSource clickSFX;
	private bool _restartPressedOnce = false;

	// Start is called before the first frame update
	void Start()
	{
		Invoke("ShowButton", 3f);
		if (restartButton)
		{
			restartButton.onClick.AddListener(RestartButtonClick);
		}
	}

	void ShowButton()
	{
		restartButton.gameObject.SetActive(true);
	}

	public void RestartButtonClick()
	{
		clickSFX.Play();
		if (!_restartPressedOnce)
		{
			_restartPressedOnce = true;
			Invoke("RestartGame", 0.1f);
		}
	}

	void RestartGame()
	{
		SceneManager.LoadScene(GameController.SCENE_MAIN);
	}
}
