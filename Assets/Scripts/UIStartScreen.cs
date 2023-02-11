using UnityEngine;
using UnityEngine.UI;

public class UIStartScreen : MonoBehaviour
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
        GameController.NewGame();
    }
}
