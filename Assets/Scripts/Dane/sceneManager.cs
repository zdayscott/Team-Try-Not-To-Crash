using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    string currentScene;
    string creditsScene = "creditsScene";
    string titleScene = "titleScreen";
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
    }
}
