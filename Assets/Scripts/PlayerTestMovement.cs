using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestMovement : MonoBehaviour {

	public Transform pj;
	public float speed = 1f;
	public Animator anim;
	// Use this for initialization
	void Start () {
		anim=GetComponent<Animator>();
		pj=GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Horizontal")>0) pj.localScale = new Vector2(1,1);
		if(Input.GetAxis("Horizontal")<0) pj.localScale = new Vector2(-1,1);
		if(Input.GetAxis("Horizontal")!=0)anim.SetBool("run",true);
		else anim.SetBool("run",false);
		pj.position = new Vector2(pj.position.x + Input.GetAxis("Horizontal")*(speed/10),pj.position.y);
	}
}
