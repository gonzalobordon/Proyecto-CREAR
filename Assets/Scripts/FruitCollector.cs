using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollector : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "durazno")
		{
			DestroyObject(other.gameObject);
		}
	}
}
