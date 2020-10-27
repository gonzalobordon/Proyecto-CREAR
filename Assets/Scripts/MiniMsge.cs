using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMsge : MonoBehaviour {
	public GameObject msge;
	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag=="Player")	msge.SetActive(true);
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag=="Player")	msge.SetActive(false);
	}
}

//personaje acerca a vicuña y aparece mensaje