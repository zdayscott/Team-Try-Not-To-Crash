using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System;

public class EINmanager : MonoBehaviour
{
    public TextAsset firstWorld;
    public Text displayText;
    private string currentLine = "";
    private string lineWithInts = "";
    private List<string> firstWorldLines;

    private List<string> chosenLines = new List<string>();
    private List<int> currentOptions;


    private int wrongAnswers = 0;
    private int correctAnswers = 0;
    // Start is called before the first frame update
    void Start()
    {
        firstWorldLines = firstWorld.text.Split('\n').ToList();
        displayText.text = "Hello world. My name is E.I.N., or Emotionally Intelligent Network. How can I assist you today?";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private string getLine()
    {
        string totalLine = firstWorldLines[UnityEngine.Random.Range(0, firstWorldLines.Count)];
        while (chosenLines.Contains(totalLine) == true)
        {
            totalLine = firstWorldLines[UnityEngine.Random.Range(0, firstWorldLines.Count)];
        }
        chosenLines.Add(totalLine);
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
        //print("second button clicked");
    }

    private void getButton(int i)
    {
        getLine();
        getInts();
        if (currentOptions.Contains(i))
        {
            correctAnswers++;
        }
        else
        {
            wrongAnswers++;
        }
        print("" + correctAnswers + " " + wrongAnswers);
        updateDisplay();
    }

    private void updateDisplay()
    {
        displayText.text = currentLine;
    }
}
