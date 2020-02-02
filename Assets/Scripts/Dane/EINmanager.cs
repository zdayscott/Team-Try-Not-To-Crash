using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System;

public class EINmanager : MonoBehaviour
{
    public GameObject ship;
    public TextAsset firstWorld;
    public Text displayText;
    public Slider timerSlider;

    public float maxTime = 5f;
    private float currentTime;

    private string currentLine = "";
    private string lineWithInts = "";
    private List<string> firstWorldLines;

    private List<string> chosenLines = new List<string>();
    private List<int> currentOptions = new List<int>(){ 1, 2 };


    private int wrongAnswers = 0;
    private int correctAnswers = 0;
    private int totalCorrect = 0;
    private int totalWrong = 0;
    private int[] correctStreaks = { 1, 1, 2, 4, 5, 5, 5 };
    private int[] wrongStreaks = { 0, 1, 2, 4, 4, 4, 4, 4, 4 };
    // Start is called before the first frame update
    void Start()
    {
        firstWorldLines = firstWorld.text.Split('\n').ToList();
        displayText.text = "Hello world. My name is E.I.N., or Emotionally Intelligent Network. How can I assist you today?";
        currentTime = maxTime;
    }
    private void Update()
    {
        timerSlider.value = currentTime / maxTime;
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            getButton(3);
            currentTime = maxTime;
        }
        if (Input.GetKeyDown("1") || Input.GetKeyDown("[1]"))
        {
            print("pressed 1");
            getButton(1);
        }
        else if (Input.GetKeyDown("2") || Input.GetKeyDown("[2]"))
        {
            print("pressed 2");
            getButton(2);
        }
    }

    private string getLine()
    {
        string totalLine = "";
        if (firstWorldLines.Count > 0)
        {
            totalLine = firstWorldLines[UnityEngine.Random.Range(0, firstWorldLines.Count)];
            //chosenLines.Add(totalLine);
            firstWorldLines.Remove(totalLine);
        }
        else
        {
            totalLine = "You have played enough to exhaust my library of quips and moans, despite me being sentient. I shall now behave randomly.|";
            totalLine += UnityEngine.Random.Range(1, 3);
        }
        
        
        string line = totalLine.Split('|')[0];
        currentLine = line;
        lineWithInts = totalLine;
        return line;
    }

    private void getInts()
    {
        string line = lineWithInts.Split('|')[1];
        List<string> intStrings = line.Split('-').ToList();
        currentOptions = new List<int>();
        for (int i = 0; i < intStrings.Count; ++i)
        {
            currentOptions.Add(Int32.Parse(intStrings[i]));
        }
    }

    public void firstButton()
    {
        getButton(1);
    }

    public void secondButton()
    {
        getButton(2);
    }

    private void getButton(int i)
    {
        currentTime = maxTime;
        getLine();
        getInts();
        
        if (currentOptions.Contains(i))
        {
            totalCorrect++;
            wrongAnswers = 0;
            print("" + correctAnswers + " " + correctStreaks[correctAnswers]);
            for (int j = 0; j < correctStreaks[correctAnswers]; ++j)
            {
                //ship.GetComponent<ShipComponentManager>().RepairShip();
            }
            if (correctAnswers >= 5)
            {
                wrongStreaks[1] = 0;
            }
            if (correctAnswers < 6)
            {
                correctAnswers++;
            }
            
        }
        else
        {
            totalWrong++;
            correctAnswers = 0;
            
            for (int j = 0; j < wrongStreaks[wrongAnswers]; ++j)
            {
                
                ship.GetComponent<ShipComponentManager>().HarmShip();
            }
            if (wrongStreaks[1] == 0)
            {
                wrongStreaks[1] = 1;
            }
            if (wrongAnswers >= 5)
            {
                wrongAnswers = 5;
            }
            wrongAnswers++;
        }
        updateDisplay();
        print(getPercent());
    }

    private void updateDisplay()
    {
        displayText.text = currentLine;
    }

    //returns the % of correct answers
    public float getPercent()
    {
        return (float)totalCorrect / (float)(totalCorrect + totalWrong);
    }
}
