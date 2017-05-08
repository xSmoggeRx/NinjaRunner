using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour {
   
    public Text score;
    string texto = "Score: 0";
    // Use this for initialization

    void Awake()
    {
        
    }

    void Start()
    {
        score = GetComponent<Text>();

        score.text = "Score: 0";

    }
    void Update()
    {
        

        score = GetComponent<Text>();
        score.text = "Score: " + PlayerPrefs.GetInt("score") ;
    }
}
