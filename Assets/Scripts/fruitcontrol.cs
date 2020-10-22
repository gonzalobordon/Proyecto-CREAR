using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitcontrol : MonoBehaviour {
	public GameObject fruta;
	public float tempo = 65f;
	public float offset = 3f;
	public float rango = 7f;
	public float bpm;
	public float timing;
	public int totalcount = 150;
	public int cont=0;
	// Use this for initialization
	void Start () {
		bpm = 60/tempo;
		timing = bpm + offset;
	}
	
	// Update is called once per frame
	void Update () {
		if (cont<totalcount)
		{
			if (timing>0) timing -= Time.deltaTime;
			else{
				cont+=1;
				Debug.Log(cont);
				gameObject.transform.position = new Vector2(Random.Range(-rango,rango),gameObject.transform.position.y);
				Instantiate(fruta,gameObject.transform.position,gameObject.transform.rotation);
				timing = bpm;
			}
		}
	}
}
