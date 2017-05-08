using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private int score;
    private static float distance;
    private AudioSource audioItem;
    public AudioClip getItem;
    // Use this for initialization

    void Awake()
    {
        audioItem = GetComponent<AudioSource>();
    }
    void Start () {
        score = 0;
        distance = 0;
	}
	
	// Update is called once per frame
	void Update () {
        PlayerPrefs.SetInt("score",score);
        PlayerPrefs.SetFloat("distance", distance);
	}
    public int GetScore()
    {
        return score;
    }

    public static float GetDistance()
    {
        return distance;
    }

    public void SumarScore()
    {
        score += 10;
        audioItem.PlayOneShot(getItem, 0.7f);
    }

    public static void SumarDistance(float a)
    {
        
        distance+=a;
    }


}
