using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyDestroyer : MonoBehaviour {
    public Rigidbody ennemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.R))
            Destroy(ennemy.gameObject);
	}
}
