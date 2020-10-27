using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {
	public float speed = 5f;
	public float jump = 30;
	private bool enpiso;
	public Rigidbody2D rb;
	public Animator anim;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		

		enpiso = Physics2D.OverlapCircle(new Vector2(gameObject.transform.position.x,(gameObject.transform.position.y)-1.6f*gameObject.transform.localScale.y),0.25f,1<<8);
		float x = Input.GetAxis("Horizontal");

		rb.velocity= new Vector2(x*speed,rb.velocity.y);
		if (enpiso)
		{
			anim.SetBool("run",true);
			if (Input.GetButton("Jump")) rb.AddForce(new Vector2(0,jump),ForceMode2D.Impulse);
		}
		else anim.SetBool("run",false);
	}

}
	



		