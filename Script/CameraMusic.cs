using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMusic : MonoBehaviour {
    void Awake()
    {
        DontDestroyOnLoad(this);
        GameObject[] tmp= GameObject.FindGameObjectsWithTag("MainCamera");
        if (tmp[1]!=this)
        {
            Destroy(tmp[1]);
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
