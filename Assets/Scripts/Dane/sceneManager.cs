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
    string helpScene = "helpScene";

    string lastScene;

    public float percentCorrect = .2f;
    public int asteroidsHit = 13;
    public float timeSurvived = 15.6f;

    private Button playGame;
    private Button credits;
    private Button quitButton;
    private Button returnToTitle;
    private Button help;
    private Text finalDisplayText;

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
        lastScene = currentScene;
        DontDestroyOnLoad(this.gameObject);
    }
    private void buttonAssigner()
    {
        if (GameObject.Find("playGame") != null)
        {
            playGame = GameObject.Find("playGame").GetComponent<Button>();
            playGame.onClick.AddListener(switchToGame);
        }
        if (GameObject.Find("credits") != null)
        {
            credits = GameObject.Find("credits").GetComponent<Button>();
            credits.onClick.AddListener(switchToCredits);
        }
        if (GameObject.Find("quitGame") != null)
        {
            quitButton = GameObject.Find("quitGame").GetComponent<Button>();
            quitButton.onClick.AddListener(quitGame);
        }
        if (GameObject.Find("returnToTitle") != null)
        {
            returnToTitle = GameObject.Find("returnToTitle").GetComponent<Button>();
            returnToTitle.onClick.AddListener(switchToTitleScene);
        }
        if (GameObject.Find("help") != null)
        {
            help = GameObject.Find("help").GetComponent<Button>();
            help.onClick.AddListener(switchToHelpScene);
        }
        if (GameObject.Find("finalDisplayText") != null)
        {
            finalDisplayText = GameObject.Find("finalDisplayText").GetComponent<Text>();
            finalDisplayText.text = endScreenString();
        }
    }
    private void Start()
    {
        buttonAssigner();
    }

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene().name;
        if (Input.GetKeyDown("escape") && currentScene == creditsScene)
        {
            switchToTitleScene();
        }

        if (manualSwitch && Input.GetKeyDown("p"))
        {
            switchToEndGame();
        }
        
        if (currentScene != lastScene)
        {
            buttonAssigner();
        }
        lastScene = currentScene;
    }
    public void switchToHelpScene()
    {
        SceneManager.LoadScene(helpScene);
        buttonAssigner();
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

    private string endScreenString()
    {
        string finalString = "";
        finalString += "Percent correct with E.I.N. - " + (100f * percentCorrect) + "%\n";
        finalString += "Asteroids hit - " + asteroidsHit + "\n";
        finalString += "Time survived - " + timeSurvived + " seconds\n";
        finalString += "-----------------------------\n";
        finalString += "TOTAL SCORE - " + ((10f * timeSurvived + (float)asteroidsHit) * (1f + percentCorrect));


        return finalString;
    }
}
