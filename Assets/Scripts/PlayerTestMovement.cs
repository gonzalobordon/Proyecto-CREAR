using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestMovement : MonoBehaviour {

	public Transform pj;
	public float speed = 1f;

	// Use this for initialization
	void Start () {
		pj=GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		pj.position = new Vector2(pj.position.x + Input.GetAxis("Horizontal")*(speed/10),pj.position.y);
	}
}
