using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private GameObject textBox;
    public Text healthBar;
    public float currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Text>();
        currentHealth = 4;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeHealth(int change)
    {     
        if(currentHealth < 4 && change > 0)
        {
            currentHealth += change;
        }
        if (currentHealth > 1 && change < 0)
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
            SoundManager.instance.EinIsSadSfx();
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
    }
    public void death()
    {

    }
}
