using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over_Screen : MonoBehaviour
{
    [SerializeField] private GameObject ShitButton;
    [SerializeField] private AudioSource ClickSFX;
    private bool Pressed = false;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Button", 3f);
    }

    void Button()
    {
        ShitButton.SetActive(true);
    }

    public void PRESSME()
    {
        ClickSFX.Play();
        if (!Pressed)
        {
            Pressed = true;
            Invoke("loadscene", 0.5f);
        }
    }

    void loadscene()
    {
        SceneManager.LoadScene("Main");
    }
}
