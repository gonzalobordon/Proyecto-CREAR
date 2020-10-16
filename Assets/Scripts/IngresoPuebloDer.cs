﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngresoPuebloDer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player")
		{
			SceneManager.LoadScene("Pueblo",LoadSceneMode.Single);
			other.transform.position = new Vector2(-14,-1.25f);
		}
	}
}
