using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 5f;
	public float jump = 10;
	public float gravity = 9.8f;
	private bool enpiso;
	public Rigidbody2D rb;
	public Animator anim;
	private SpriteRenderer spr;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		spr = GetComponent<SpriteRenderer>();
	}
	
	void FixedUpdate () {
		rb.gravityScale = gravity;
		float x = Input.GetAxis("Horizontal");
		rb.velocity= new Vector2(x*speed,rb.velocity.y);
		enpiso = Physics2D.OverlapCircle(new Vector2(gameObject.transform.position.x,(gameObject.transform.position.y)-1.6f*gameObject.transform.localScale.y),0.25f,1<<8);
		if (enpiso & Input.GetButtonDown("Jump"))
		{
			rb.AddForce(new Vector2(0,jump),ForceMode2D.Impulse);
		}
		if((x!=0) & enpiso){
			anim.SetBool("run",true);
		}else anim.SetBool("run",false);

		if (x>0) spr.flipX = false;
		if (x<0) spr.flipX = true;
	}
}
