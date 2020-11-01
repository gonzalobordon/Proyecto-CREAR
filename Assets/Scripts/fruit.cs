using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class fruit : MonoBehaviour {

	public float speedX = 0f;
	public float speedY = 0f;
	public float speedrot = 0f;
	public bool deleteable = false;
	public float lifetime = 5f;
	void Update () {
		gameObject.transform.position = new Vector2 (gameObject.transform.position.x+speedX,gameObject.transform.position.y+speedY);
		transform.Rotate(new Vector3(0,0,speedrot));
		if (deleteable)
		{
			DestroyObject(gameObject,lifetime);
		}
	}
}

[CustomEditor(typeof(fruit))]
public class fruitEditor : Editor{

    public override void OnInspectorGUI()
    {
        var fruit = target as fruit;
		fruit.speedX = EditorGUILayout.Slider("X",fruit.speedX,-0.25f,0.25f);
		fruit.speedY = EditorGUILayout.Slider("Y",fruit.speedY,-0.25f,0.25f);
		fruit.speedrot = EditorGUILayout.Slider("Rotacion",fruit.speedrot,-10f,10f);
		fruit.deleteable = GUILayout.Toggle(fruit.deleteable,"Autodestruccion");
		if (fruit.deleteable) fruit.lifetime = EditorGUILayout.FloatField("Conteo Regresivo",fruit.lifetime);
    }
}
