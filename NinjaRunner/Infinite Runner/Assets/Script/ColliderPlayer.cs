using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPlayer : MonoBehaviour {
    public GameObject papa; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            Player player = papa.GetComponent<Player>();
            player.CollisionHorizontal();
        }
    }
}
