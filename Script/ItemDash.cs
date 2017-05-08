using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDash : MonoBehaviour {
    private GameObject gameController;

    void Awake()
    {
        gameController = GameObject.Find("GameController");
    }

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("TRIGGER");
        if (collider.gameObject.tag.Contains("Player"))
        {

            // GetComponent<SpriteRenderer>().enabled = false;
            Destroy(this.gameObject);
           
            
            Player.SumarDash();

            GameController gameControllerScript = gameController.GetComponent<GameController>();
            gameControllerScript.SumarScore();
        }
    }

  
}
