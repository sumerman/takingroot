using UnityEngine;
using UnityEngine.UI;

public class IntroController : MonoBehaviour
{
    [SerializeField] private Text IntroText;
    [SerializeField] private string[] Line;
    [SerializeField] private Animator MyAnim;
    [SerializeField] private AudioSource Soundtrack;
    [SerializeField] private AudioSource Click;
    [SerializeField] private GameObject IntroSlide;
    [SerializeField] private GameObject[] FinalSlide;
    [SerializeField] private GameObject SkipText;
    private bool _control = false;
    private int _currentLine = 0;

    private void Start()
    {
        Invoke("IntroStart", 1f);
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape) && Input.anyKey && _control)
        {
            _control = false;
            MyAnim.Play("Text Fade In", 0, 0);
            _currentLine++;
            if (_currentLine <= Line.Length - 1)
            {
                Invoke("ControlOn", 0.5f);
                Click.Play();
                IntroText.text = Line[_currentLine];
            }
            else
            {
                IntroText.gameObject.SetActive(false);
                IntroSlide.SetActive(false);
                Soundtrack.Stop();
                SkipText.SetActive(false);
                for (int i = 0; i < FinalSlide.Length; i++)
                {
                    FinalSlide[i].SetActive(true);
                }
                Invoke("StartGame", 2.5f);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && _control)
        {
            _control = false;
            StartGame();
        }
    }

    void StartGame()
    {
        GameController.NewGame();
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
        _control = true;
    }
}
