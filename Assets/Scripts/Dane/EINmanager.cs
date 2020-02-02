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
    private string currentLine = "";
    private string lineWithInts = "";
    private List<string> firstWorldLines;

    private List<string> chosenLines = new List<string>();
    private List<int> currentOptions;


    private int wrongAnswers = 0;
    private int correctAnswers = 0;
    private int[] correctStreaks = { 1, 1, 2, 4, 5, 5, 5 };
    private int[] wrongStreaks = { 0, 1, 2, 4, 4, 4, 4, 4, 4 };
    // Start is called before the first frame update
    void Start()
    {
        firstWorldLines = firstWorld.text.Split('\n').ToList();
        displayText.text = "Hello world. My name is E.I.N., or Emotionally Intelligent Network. How can I assist you today?";
    }
    
    private string getLine()
    {
        string totalLine = "";
        if (firstWorldLines.Count > 0)
        {
            totalLine = firstWorldLines[UnityEngine.Random.Range(0, firstWorldLines.Count)];
            chosenLines.Add(totalLine);
        }
        else
        {
            totalLine = "You have played enough to exhaust my library of quips and moans, despite me being sentient. I shall now behave randomly.|";
            totalLine += UnityEngine.Random.Range(1, 3);
        }
        
        while (chosenLines.Contains(totalLine) == true)
        {
            totalLine = firstWorldLines[UnityEngine.Random.Range(0, firstWorldLines.Count)];
        }
        
        firstWorldLines.Remove(totalLine);
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
        getLine();
        getInts();
        if (currentOptions.Contains(i))
        {
            wrongAnswers = 0;
            
            for (int j = 0; j < correctStreaks[correctAnswers]; ++j)
            {
                
                ship.GetComponent<ShipComponentManager>().RepairShip();
            }
            print("Healing " + correctStreaks[correctAnswers] + " time(s)");
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
            correctAnswers = 0;
            
            for (int j = 0; j < wrongStreaks[wrongAnswers]; ++j)
            {
                
                ship.GetComponent<ShipComponentManager>().HarmShip();
            }
            print("Hurting " + wrongStreaks[wrongAnswers] + " time(s)");
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
    }

    private void updateDisplay()
    {
        displayText.text = currentLine;
    }
}
