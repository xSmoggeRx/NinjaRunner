using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {
    public GameObject[] plataformas;
    public GameObject[] item;
	// Use this for initialization
	void Start () {
        Generar();	
	}
	
	void Generar()
    {
        Instantiate(plataformas[Random.Range(0, plataformas.Length)], transform.position, Quaternion.identity);
        if (Random.Range(0,5)==2)
        {
            Instantiate(item[Random.Range(0, item.Length)], new Vector3(transform.position.x, transform.position.y+2,transform.position.z), Quaternion.identity);
        }
        Invoke("Generar", 1.2f);
    }
}
