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


    private List<string> firstWorldLines;
    // Start is called before the first frame update
    void Start()
    {
        firstWorldLines = firstWorld.text.Split('\n').ToList();
        displayText.text = "Hello world. My name is E.I.N., or Emotionally Intelligent Network. How can I assist you today?";
        print(getLine("insert line here|1, 2"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private string getLine(string totalLine)
    {
        string line = totalLine.Split('|')[0];
        return line;
    }

    private List<int> getInts(string totalLine)
    {
        string line = totalLine.Split('|')[1];
        List<string> intStrings = line.Split(',').ToList();
        List<int> ints = new List<int>();
        for (int i = 0; i < intStrings.Count; ++i)
        {
            ints.Add(Int32.Parse(intStrings[i]));
        }
        return ints;
    }

    public void firstButton()
    {
        print("first button clicked");
    }

    public void secondButton()
    {
        print("second button clicked");
    }
}
