using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneManager : MonoBehaviour
{
    private static sceneManager _instance;

    public static sceneManager Instance { get {return _instance; }}

    public bool manualSwitch = false;

    string currentScene;
    string creditsScene = "creditsScene";
    string titleScene = "titleScreen";
    string mainGame = "mainGame";
    string endScene = "endGame";

    public float percentCorrect = 0f;
    public int asteroidsHit = 0;
    public float timeSurvived = 0f;

    private Button playGame;
    private Button credits;
    private Button quitButton;
    private Button returnToTitle;

    private float timeElapsed = 0;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        currentScene = SceneManager.GetActiveScene().name;
        DontDestroyOnLoad(this.gameObject);
    }
    private void buttonAssigner()
    {
        if (GameObject.Find("playGame") != null)
        {
            print("found play game");
            playGame = GameObject.Find("playGame").GetComponent<Button>();
            playGame.onClick.AddListener(switchToGame);
        }
        if (GameObject.Find("credits") != null)
        {
            print("found credits");
            credits = GameObject.Find("credits").GetComponent<Button>();
            credits.onClick.AddListener(switchToCredits);
        }
        if (GameObject.Find("quitGame") != null)
        {
            print("quit game found");
            quitButton = GameObject.Find("quitGame").GetComponent<Button>();
            quitButton.onClick.AddListener(quitGame);
        }
        if (GameObject.Find("returnToTitle") != null)
        {
            print("return to title found");
            returnToTitle = GameObject.Find("returnToTitle").GetComponent<Button>();
            returnToTitle.onClick.AddListener(switchToTitleScene);
        }
    }
    private void Start()
    {
        buttonAssigner();
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape") && currentScene == creditsScene)
        {
            switchToTitleScene();
        }

        if (manualSwitch && Input.GetKeyDown("p"))
        {
            switchToEndGame();
        }
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= 1f)
        {
            buttonAssigner();
            timeElapsed = 0f;
        }
    }
    public void switchToCredits()
    {
        SceneManager.LoadScene(creditsScene);
        buttonAssigner();
    }

    public void switchToTitleScene()
    {
        SceneManager.LoadScene(titleScene);
        SoundManager.instance.MusicStart();
        SoundManager.instance.EinIsDead();
        SoundManager.instance.EinPulseStop();
        buttonAssigner();

    }
    public void quitGame()
    {
        //buttonAssigner();
        print("trying to quit");
        Application.Quit();
    }

    public void switchToGame()
    {
        SceneManager.LoadScene(mainGame);
        SoundManager.instance.EinIsHappySfx();
        SoundManager.instance.EinPulseStart();
        SoundManager.instance.MusicStop();
        buttonAssigner();
    }

    public void switchToEndGame()
    {
        SceneManager.LoadScene(endScene);
        SoundManager.instance.EinIsDead();
        SoundManager.instance.EinPulseStop();
        SoundManager.instance.MusicStart();
        buttonAssigner();

    }

    public void SetEndGame(float correct, int astHit, float timeS)
    {
        percentCorrect = correct;
        asteroidsHit = astHit;
        timeSurvived = timeS;
    }
}
