using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

public class CameraController : MonoBehaviour {
	public Transform target;
	[Range(0f,1f)]
	public float velocity = 0.25f;
	[Header("Limite Vertical")]
	[Tooltip("Limite Superior")]
	public float maxY = 9f;
	[Tooltip("Limite Inferior")]
	public float minY = -9f;
	[Header("Limite Horizontal")]
	[Tooltip("Limite Izquierdo")]
	public float minX = 10f;
	[Tooltip("Limite Derecho")]
	public float maxX = -10f;
	void FixedUpdate () {
		Vector3 targetpos = new Vector3(
										Mathf.Clamp(target.position.x,minX,maxX),
										Mathf.Clamp(target.position.y,minY,maxY),
										transform.position.z
										);
		transform.position = Vector3.Lerp(transform.position,targetpos,velocity);
	}
}
