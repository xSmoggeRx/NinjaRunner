using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashText : MonoBehaviour {

    public Text score;
    string texto = "0";
    // Use this for initialization

    void Awake()
    {

    }

    void Start()
    {
        score = GetComponent<Text>();

        score.text = "0";

    }
    void Update()
    {


        score = GetComponent<Text>();
        score.text =""+PlayerPrefs.GetInt("dash");
    }
}
