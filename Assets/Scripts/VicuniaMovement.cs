using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VicuniaMovement : MonoBehaviour {

	public Transform npc;
	public float actiontime= 2f;
	private float lifetime;
	private float direction; 
	// Use this for initialization
	void Start () {
		npc=GetComponent<Transform>();
		lifetime=actiontime;
		direction=Random.Range(-0.01f,0.01f);
	}
	
	// Update is called once per frame
	void Update () {
		if(direction<0) npc.localScale=new Vector2(1,1);
		else npc.localScale=new Vector2(-1,1);
		if (lifetime>0)
		{
			npc.position = new Vector2(npc.position.x+direction,npc.position.y);
			lifetime -= Time.deltaTime;
		}else 	{lifetime = Random.Range(1,3);
				direction=Random.Range(-0.01f,0.01f);}
	}
}
