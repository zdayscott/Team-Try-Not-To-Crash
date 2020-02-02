using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    string currentScene;
    string creditsScene = "creditsScene";
    string titleScene = "titleScreen";
    string mainGame = "mainGame";
    string endScene = "endGame";

    public float percentCorrect = 0f;
    public int asteroidsHit = 0;
    public float timeSurvived = 0f;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape") && currentScene == creditsScene)
        {
            switchToTitleScene();
        }
    }
    public void switchToCredits()
    {
       
        SceneManager.LoadScene(creditsScene);
    }

    public void switchToTitleScene()
    {


        SceneManager.LoadScene(titleScene);
        SoundManager.instance.MusicStart();
        SoundManager.instance.EinIsDead();
        SoundManager.instance.EinPulseStop();

    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void switchToGame()
    {
        SceneManager.LoadScene(mainGame);
        SoundManager.instance.EinIsHappySfx();
        SoundManager.instance.EinPulseStart();
        SoundManager.instance.MusicStop();
    }

    public void endGame()
    {
        SceneManager.LoadScene(endScene);
    }
}
