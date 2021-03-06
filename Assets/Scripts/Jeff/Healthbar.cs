﻿using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private GameObject textBox;
    public Text healthBar;
    public float currentHealth;

    [SerializeField]
    private Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        if(!healthBar)
        {
            healthBar = GetComponent<Text>();
        }

        currentHealth = 4;
    }

    public void changeHealth(int change)
    {     
        if(currentHealth < 4 && change > 0)
        {
            currentHealth += change;
        }
        if (currentHealth > 0 && change < 0)
        {
            currentHealth += change;
        }

        if (currentHealth == 4)
        {
            //comments kill game.
            healthBar.text = "An Overwhelming Surplus of Diggity";
            print("An Overwhelming Surplus of Diggity");
            SoundManager.instance.EinIsHappySfx();

        }
        else if (currentHealth == 3)
        {
            healthBar.text = "A Fair Amount of Diggity";
            print("A Fair Amount of Diggity");
            SoundManager.instance.EinIsSadSfx();
        }
        else if (currentHealth == 2)
        {
            healthBar.text = "Hardly Any Diggity";
            print("Hardly Any Diggity");
            //SoundManager.instance.EinIsSadSfx();
        }
        else if (currentHealth == 1)
        {
            healthBar.text = "No Diggity";
            print("No Diggity");
            SoundManager.instance.EinIsDepressedSfx();
        }
        else
        {
            death();
        }

        slider.value = currentHealth/4;
    }
    public void death()
    {
        sceneManager.Instance.SetEndGame(FindObjectOfType<EINmanager>().getPercent(), ScoreManager.instance.GetAstHit(), ScoreManager.instance.GetTime());
        sceneManager.Instance.switchToEndGame();
    }
}
