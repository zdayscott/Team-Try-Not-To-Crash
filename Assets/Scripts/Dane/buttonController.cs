using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonController : MonoBehaviour
{
    private Button playGame;
    private Button credits;
    private Button quitGame;


    
    // Start is called before the first frame update
    void Start()
    {
        playGame = GameObject.Find("playGame").GetComponent<Button>();
        credits = GameObject.Find("credits").GetComponent<Button>();
        quitGame = GameObject.Find("quitGame").GetComponent<Button>();

        if (playGame != null)
        {
            playGame.onClick.AddListener(sceneManager.Instance.switchToGame);
        }
        if (credits != null)
        {
            credits.onClick.AddListener(sceneManager.Instance.switchToCredits);
        }
        if (credits != null)
        {
            quitGame.onClick.AddListener(sceneManager.Instance.quitGame);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
