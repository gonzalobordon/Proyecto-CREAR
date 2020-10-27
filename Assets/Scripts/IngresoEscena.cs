using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IngresoEscena : MonoBehaviour {
	public string escena;
	public bool button = false;
	public string namebutton = "Fire1";
	public float posx = 0f;
	public float posy = 0f; 
	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Player")
		{
			if (button==true)
			{	
				if (Input.GetButtonDown(namebutton))
				{
					SceneManager.LoadScene(escena,LoadSceneMode.Single);
					other.transform.position = new Vector2(posx,posy);	
				}
			}else{
					SceneManager.LoadScene(escena,LoadSceneMode.Single);
					other.transform.position = new Vector2(posx,posy);
			} 
		}
	}
}
