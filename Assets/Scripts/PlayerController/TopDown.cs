using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDown : MonoBehaviour {
	public float speed = 5f;
	public Rigidbody2D rb;
	public Animator anim;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		rb.gravityScale = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float y = Input.GetAxis("Vertical");
		float x = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(x*speed,y*speed);
		if(x!=0)	anim.SetBool("run",true);
			else anim.SetBool("run",false);
		if (x>0) gameObject.transform.localScale =  new Vector2(1,1);
		if (x<0) gameObject.transform.localScale =  new Vector2(-1,1);
	}
}
