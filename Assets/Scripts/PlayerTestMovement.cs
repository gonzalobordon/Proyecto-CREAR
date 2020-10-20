using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestMovement : MonoBehaviour {

	public Transform pj;
	public float speed = 1f;
	public float limitposx = 16f;
	public float limitposy = 7f;
	public Animator anim;
	public bool omnidir = false;
	// Use this for initialization
	void Start () {
		anim=GetComponent<Animator>();
		pj=GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Horizontal")!=0)anim.SetBool("run",true);	else anim.SetBool("run",false);
		if(Input.GetAxis("Horizontal")>0) pj.localScale = new Vector2(1,1);
		if(Input.GetAxis("Horizontal")<0) pj.localScale = new Vector2(-1,1);
		if(Input.GetAxis("Vertical")>0 & omnidir==true)anim.SetBool("up",true); else anim.SetBool("up",false);
		if(Input.GetAxis("Vertical")<0 & omnidir==true)anim.SetBool("down",true); else anim.SetBool("down",false);
		if (omnidir) pj.position = new Vector2(Mathf.Clamp(pj.position.x + Input.GetAxis("Horizontal")*(speed/10),-limitposx,limitposx) ,Mathf.Clamp(pj.position.y + Input.GetAxis("Vertical")*(speed/10),-limitposy,limitposy));
		else pj.position = new Vector2(Mathf.Clamp(pj.position.x + Input.GetAxis("Horizontal")*(speed/10),-limitposx,limitposx) ,pj.position.y);
	}
}
