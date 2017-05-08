using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform personaje;
    public float separacion=5f;
    public float velocidad;
	
	// Update is called once per frame
	void Update () {
        //transform.position = new Vector3(personaje.position.x+separacion, transform.position.y, transform.position.z);	
        GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, GetComponent<Rigidbody2D>().velocity.y);
    }
}
