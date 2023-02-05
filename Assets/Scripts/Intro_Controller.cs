using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro_Controller : MonoBehaviour
{
    [SerializeField] private Text IntroText;
    [SerializeField] private string[] Line;
    [SerializeField] private Animator MyAnim;
    [SerializeField] private AudioSource Soundtrack;
    [SerializeField] private AudioSource Click;
    [SerializeField] private GameObject IntroSlide;
    [SerializeField] private GameObject[] FinalSlide;
    [SerializeField] private GameObject SkipText;
    private bool Control = false;
    private int CurrentLine = 0;

    private void Start()
    {
        Invoke("IntroStart", 1f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Control)
        {
            Control = false;
            MyAnim.Play("Text Fade In", 0, 0);
            CurrentLine++;
            if (CurrentLine <= Line.Length - 1)
            {
                Invoke("ControlOn", 0.5f);
                Click.Play();
                IntroText.text = Line[CurrentLine];
            } else
            {
                IntroText.gameObject.SetActive(false);
                IntroSlide.SetActive(false);
                Soundtrack.Stop();
                SkipText.SetActive(false);
                for (int i = 0; i < FinalSlide.Length; i++)
                {
                    FinalSlide[i].SetActive(true);
                }
                Invoke("loadscene" ,4.5f);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && Control)
        {
            Control = false;
            loadscene();
        }
    }

    void loadscene()
    {
        SceneManager.LoadScene("Main");
    }

    void IntroStart()
    {
        IntroText.gameObject.SetActive(true);
        IntroText.text = Line[0];
        IntroSlide.SetActive(true);
        Soundtrack.Play();
        Invoke("ControlOn", 0.5f);
    }

    void ControlOn()
    {
        Control = true;
    }
}
