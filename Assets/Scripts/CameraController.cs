using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

public class CameraController : MonoBehaviour {
	public Transform target;
	[Range(0f,1f)]
	public float velocity = 0.25f;
	[Range(-5f,5f)]
	public float offsetX = 0f;
	[Range(-5f,5f)]
	public float offsetY = 0f;

	[Header("Limite Vertical")]
	[Tooltip("Limite Superior")]
	[Range(0f,25f)]
	public float maxY = 9f;
	[Tooltip("Limite Inferior")]
	[Range(-25f,0f)]
	public float minY = -9f;
	[Header("Limite Horizontal")]
	[Tooltip("Limite Izquierdo")]
	[Range(-25f,0f)]
	public float minX = 10f;
	[Tooltip("Limite Derecho")]
	[Range(0f,25f)]
	public float maxX = -10f;

	void FixedUpdate () {
		Vector3 targetpos = new Vector3(
										Mathf.Clamp(target.position.x+offsetX,minX,maxX),
										Mathf.Clamp(target.position.y+offsetY,minY,maxY),
										transform.position.z
										);
		transform.position = Vector3.Lerp(transform.position,targetpos,velocity);
	}
}
