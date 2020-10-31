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
	public bool msge = false;
	public GameObject msgr;
	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Player")
		{
			if (button)
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
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag=="Player"){
			if (msge && msgr!=null) msgr.SetActive(true);
		}	
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag=="Player"){
			if(msge && msgr!=null) msgr.SetActive(false);
	}
}


[CustomEditor(typeof(IngresoEscena))]
public class IngresoEscenaEditor : Editor{
	public bool mostrarpanel;
	public int index = 0;
	public string[] inputs = new string[]{
		"Fire1","Fire2","Fire3","Jump"
	};
	private GUILayoutOption[] options = {GUILayout.MaxWidth(150.0f),GUILayout.MinWidth(80.0f)};
	override public void OnInspectorGUI(){
		var IngresoEscena = target as IngresoEscena;

		EditorGUILayout.BeginHorizontal();
		IngresoEscena.escena = EditorGUILayout.TextField("Escena a ingresar: ",IngresoEscena.escena);
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.LabelField("Posicion Inicial");
		EditorGUILayout.BeginHorizontal();
		GUILayout.Label("X");
		IngresoEscena.posx = EditorGUILayout.FloatField(IngresoEscena.posx);
		GUILayout.Label("Y");
		IngresoEscena.posy = EditorGUILayout.FloatField(IngresoEscena.posy);
		EditorGUILayout.EndHorizontal();

		mostrarpanel = EditorGUILayout.Foldout(mostrarpanel,"Opciones");

		if (mostrarpanel)
		{
			EditorGUILayout.BeginHorizontal();
			IngresoEscena.button = GUILayout.Toggle(IngresoEscena.button,"Presionar botón");
			if (IngresoEscena.button)
			{
				index = EditorGUILayout.Popup(index,inputs);

				switch (index)
				{
					case 0: IngresoEscena.namebutton = inputs[0];
					break;
					case 1: IngresoEscena.namebutton = inputs[1];
					break;
					case 2: IngresoEscena.namebutton = inputs[2];
					break;
					case 3: IngresoEscena.namebutton = inputs[3];
					break;
				}
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			IngresoEscena.msge = GUILayout.Toggle(IngresoEscena.msge,"Objeto Mensaje");
			if (IngresoEscena.msge)
			{
				IngresoEscena.msgr = (GameObject)EditorGUILayout.ObjectField(IngresoEscena.msgr,typeof(GameObject),true);
			}
			EditorGUILayout.EndHorizontal();
		}

		}
	}
}