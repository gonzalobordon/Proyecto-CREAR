using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruit : MonoBehaviour {

	public float speedX = 1f;
	public float speedY = 0f;
	public float speedrot = 1f;
	public bool deleteable = false;
	public float lifetime = 5f;
	void Update () {
		gameObject.transform.position = new Vector2 (gameObject.transform.position.x+(speedX/10),gameObject.transform.position.y+(speedY/10));
		transform.Rotate(new Vector3(0,0,speedrot));
		if (deleteable)
		{
			DestroyObject(gameObject,lifetime);
		}
	}
}
