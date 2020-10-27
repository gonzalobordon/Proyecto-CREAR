using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitcontrol : MonoBehaviour {
	[SerializeField]
	public GameObject[] frutas;
	private int randomPrefab;
	public float tempo = 65f;
	public float offset = 3f;
	public float rangoX = 7f;
	public float rangoY = 0f;
	private float bpm;
	private float timing;
	public int totalcount = 150;
	public int cont=0;

	void Start () {
		bpm = 60/tempo;
		timing = bpm + offset;
	}
	
	void Update () {
		if (cont<totalcount)
		{
			if (timing>0) timing -= Time.deltaTime;
			else{
				cont+=1;
				//Debug.Log(cont);
				randomPrefab = Random.Range(0,frutas.Length);
				Instantiate(
					frutas[randomPrefab], 
					new Vector2(Random.Range(gameObject.transform.position.x-rangoX,gameObject.transform.position.x+rangoX),Random.Range(gameObject.transform.position.y-rangoY,gameObject.transform.position.y+rangoY)),
					gameObject.transform.rotation);
				timing = bpm;
			}
		}
	}
}
