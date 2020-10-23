using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruit : MonoBehaviour {

	public float speed = 1f;
	public float lifetime = 3f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector2 (gameObject.transform.position.x,gameObject.transform.position.y-(speed/10));
		DestroyObject(gameObject,3);
		transform.Rotate(new Vector3(0,0,speed));
	}
}
