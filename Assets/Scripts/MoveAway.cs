using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAway : MonoBehaviour {

	public Transform target;
	private Animator anim;
	public float distancia = 1f;
	public float speed = 1f;

	void Start () {
		anim = GetComponent<Animator>();
	}
	void FixedUpdate () {
		float move = speed/100;
		bool indist = Vector2.Distance(transform.position,target.position)<distancia;
		anim.SetBool("move",indist);
		if (indist)
		{
			if (transform.position.x>target.position.x) transform.position = new Vector2(transform.position.x+(move),transform.position.y);
				else transform.position = new Vector2(transform.position.x-(move),transform.position.y);
			if (transform.position.y>target.position.y) transform.position = new Vector2(transform.position.x,transform.position.y+move);
				else transform.position = new Vector2(transform.position.x,transform.position.y-move); 
		}
	}
}
