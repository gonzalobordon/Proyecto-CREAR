using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngresoEscenaIzq : MonoBehaviour {

	public string escena;
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player")
		{
			SceneManager.LoadScene(escena,LoadSceneMode.Single);
			other.transform.position = new Vector2(14f,-1.25f);
		}
	}
}
