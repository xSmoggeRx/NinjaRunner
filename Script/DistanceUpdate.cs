using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceUpdate : MonoBehaviour {

    public Text score;
    string texto = "Distance: 0";
    // Use this for initialization

    void Awake()
    {

    }

    void Start()
    {
        score = GetComponent<Text>();

        score.text = "Distance: 0";

    }
    void Update()
    {


        score = GetComponent<Text>();
        score.text = "Distance: " + Mathf.Round(PlayerPrefs.GetFloat("distance"));
    }
}
