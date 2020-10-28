using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestMovement : MonoBehaviour {
	private PlayerController lateral;
	private Scroll run;
	private TopDown aero;
	void Start(){
		lateral = GetComponent<PlayerController>();
		run = GetComponent<Scroll>();
		aero = GetComponent<TopDown>();
	}
	void OnTriggerEnter2D(Collider2D other){
		switch (other.gameObject.tag)
		{
			case "Scroll" :
				lateral.enabled = true;
				run.enabled = false;
				aero.enabled = false;
			break;
			case "Runner" :
				lateral.enabled = false;
				run.enabled = true;
				aero.enabled = false;
			break;
			case "TopDown" :
				lateral.enabled = false;
				run.enabled = false;
				aero.enabled = true;
			break;
			
		}
	}
}