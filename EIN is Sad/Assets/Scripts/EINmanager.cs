using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EINmanager : MonoBehaviour
{
    public TextAsset firstWorld;


    private List<string> firstWorldLines;
    // Start is called before the first frame update
    void Start()
    {
        firstWorldLines = firstWorld.text.Split('\n').ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void firstButton()
    {
        print("first button clicked");
    }
}
