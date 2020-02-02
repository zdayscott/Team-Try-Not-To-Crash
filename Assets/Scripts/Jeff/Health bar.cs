using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 3;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeHealth(int change)
    {
        if(currentHealth < 3 && change > 0)
        {
            currentHealth += change;
        }
        if (currentHealth > 1 && change < 0)
        {
            currentHealth -= change;
        }
    }
}
