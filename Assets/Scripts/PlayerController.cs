using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 5f;
	public float maxspeed = 2f;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float y = Input.GetAxis("Horizontal");
		rb.AddForce(Vector2.right * speed * y);
		if(rb.velocity.x>maxspeed){
			rb.velocity = new Vector2(maxspeed,rb.velocity.y);
		}
		if(rb.velocity.x<-maxspeed){
			rb.velocity = new Vector2(-maxspeed,rb.velocity.y);
		}
	}
}
