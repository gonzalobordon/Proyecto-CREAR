using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IngresoEscena : MonoBehaviour {
	public string escena;
	public float posx = 0f;
	public float posy = 0f; 
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player")
		{
			SceneManager.LoadScene(escena,LoadSceneMode.Single);
			other.transform.position = new Vector2(posx,posy);
		}
	}
}
