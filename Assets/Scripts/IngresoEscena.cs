using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
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


[CustomEditor(typeof(IngresoEscena))]
public class IngresoEscenaEditor : Editor{
	private GUILayoutOption[] options = {GUILayout.MaxWidth(70.0f),GUILayout.MinWidth(20.0f)};
	override public void OnInspectorGUI(){
		var IngresoEscena = target as IngresoEscena;

		EditorGUILayout.BeginHorizontal();
		GUILayout.Label("Escena a ingresar: ");
		IngresoEscena.escena = EditorGUILayout.TextField(IngresoEscena.escena);
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();
		GUILayout.Label("Posicion en escena: ");
		GUILayout.Label("x");
		IngresoEscena.posx = EditorGUILayout.FloatField(IngresoEscena.posx,options);
		GUILayout.Label("y");
		IngresoEscena.posy = EditorGUILayout.FloatField(IngresoEscena.posy,options);
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();
		IngresoEscena.button = GUILayout.Toggle(IngresoEscena.button,"Presionar botón");
		if (IngresoEscena.button)
		{
			IngresoEscena.namebutton = EditorGUILayout.TextField(IngresoEscena.namebutton);
		}
		EditorGUILayout.EndHorizontal();
	}
}