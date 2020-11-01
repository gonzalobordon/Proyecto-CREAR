using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Runner : MonoBehaviour {
	//variables movimiento de personaje
	public int modo = 0;
	public float[] speed = {5f,5f,5f};
	public float[] jump = {20f,20f,0f};
	public bool onjump = false;
	public bool enPiso;
	public float[] gravity = {9.8f,9.8f,0f};
	public Rigidbody2D rb;
	public Animator anim;
	private SpriteRenderer spr;

	//variables movimiento de camara
	public float[] velocity = {1,0,0.25f};
	public float[] offsetx = {0f,0f,0f};
	public float[] offsety = {0f,0f,0f};
	public float[] minx = {0f,0f,0f};
	public float[] maxx = {0f,0f,0f};
	public float[] miny = {0f,0f,0f};
	public float[] maxy = {0f,0f,0f};

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		spr = GetComponent<SpriteRenderer>();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		switch (other.gameObject.tag)
		{
			case "Scroll" :
				modo = 0;
			break;
			case "Runner" :
				modo = 1;
			break;
			case "TopDown" :
				modo = 2;
			break;
		}
	}

	void FixedUpdate () {
		Vector2 cameratarget = new Vector2(Mathf.Clamp(gameObject.transform.position.x+offsetx[modo],minx[modo],maxx[modo]),Mathf.Clamp(gameObject.transform.position.y+offsety[modo],miny[modo],maxy[modo]));
		Camera.main.transform.position = Vector2.Lerp(Camera.main.transform.position,cameratarget,velocity[modo]);
		rb.gravityScale = gravity[modo];
		enPiso = Physics2D.OverlapCircle(new Vector2(gameObject.transform.position.x,(gameObject.transform.position.y)-1.6f*gameObject.transform.localScale.y),0.25f,1<<8);
		rb.velocity = new Vector2(Input.GetAxis("Horizontal")*speed[modo],rb.velocity.y);
		switch (modo)
		{
			case 0:	if (Input.GetButtonDown("Jump") && enPiso) rb.velocity = new Vector2(rb.velocity.x,jump[modo]);
					if(Input.GetAxis("Horizontal")>0) spr.flipX = false;
					if(Input.GetAxis("Horizontal")<0) spr.flipX = true;
					if (enPiso && Input.GetAxis("Horizontal")!=0) anim.SetBool("run",true);
					else anim.SetBool("run",false);
			break;
			case 1:	
					spr.flipX = false;
					if (enPiso) 
					{	
						anim.SetBool("run",true);
						if (Input.GetButtonDown("Jump")){
						onjump = true;
						rb.velocity = new Vector2(rb.velocity.x,jump[modo]);
						}
					}else{
						anim.SetBool("run",false);
						if (Input.GetButtonDown("Jump") && onjump)
						{
						onjump = false;
						rb.velocity = new Vector2(rb.velocity.x,jump[modo]);	
						} 
					}
			break;
			case 2:
					if(Input.GetAxis("Horizontal")>0) spr.flipX = false;
					if(Input.GetAxis("Horizontal")<0) spr.flipX = true;
					rb.velocity = new Vector2(rb.velocity.x,Input.GetAxis("Vertical")*speed[modo]);
					if(Input.GetAxis("Horizontal")!=0) anim.SetBool("run",true);
					else anim.SetBool("run",false);
			break;
			default:if (Input.GetButton("Jump") && enPiso) rb.velocity = new Vector2(rb.velocity.x,jump[modo]);
					if(Input.GetAxis("Horizontal")>0) spr.flipX = false;
					if(Input.GetAxis("Horizontal")<0) spr.flipX = true;
					if (enPiso && Input.GetAxis("Horizontal")!=0) anim.SetBool("run",true);
					else anim.SetBool("run",false);
			break;
		}
	}
}


[CustomEditor(typeof(Runner))]
public class RunnerEditor : Editor{
	public bool playerfold;
	public bool camfold;
	public string[] modes = new string[]{"Scroll Lateral","Infite Runner","TopDown"};
    override public void OnInspectorGUI()
    {
        var Runner = target as Runner;
		EditorGUILayout.BeginVertical();
		EditorGUILayout.BeginHorizontal();
		Runner.modo = EditorGUILayout.Popup("Tipo de Movimiento",Runner.modo,modes);
		EditorGUILayout.EndHorizontal();
		playerfold = EditorGUILayout.Foldout(playerfold,"Control Personaje");
		if (playerfold)
		{
			Runner.speed[Runner.modo] = EditorGUILayout.Slider("Velocidad",Runner.speed[Runner.modo],0f,30f);
			Runner.jump[Runner.modo] = EditorGUILayout.Slider("Fuerza de Salto",Runner.jump[Runner.modo],0f,50f);
			Runner.gravity[Runner.modo] = EditorGUILayout.Slider("Gravedad",Runner.gravity[Runner.modo],0f,9.8f);
		}

		
		camfold = EditorGUILayout.Foldout(camfold,"Opciones de camara");
		if (camfold)
		{
			Runner.velocity[Runner.modo]=EditorGUILayout.Slider("Velocidad de rastreo",Runner.velocity[Runner.modo],0f,1f);
			EditorGUILayout.Space();
			EditorGUILayout.BeginHorizontal();
			Runner.minx[Runner.modo]=EditorGUILayout.Slider("Limite Izquierdo",Runner.minx[Runner.modo],-100f,0f);
			Runner.maxx[Runner.modo]=EditorGUILayout.Slider("Limite Derecho",Runner.maxx[Runner.modo],0f,100f);
			EditorGUILayout.EndHorizontal();
			if (Runner.minx[Runner.modo]<0 || Runner.maxx[Runner.modo]>0)
			{
				Runner.offsetx[Runner.modo]=EditorGUILayout.Slider("Desfase en X",Runner.offsetx[Runner.modo],Runner.minx[Runner.modo],Runner.maxx[Runner.modo]);
			}
			EditorGUILayout.Space();
			EditorGUILayout.BeginHorizontal();
			Runner.miny[Runner.modo]=EditorGUILayout.Slider("Limite Inferior",Runner.miny[Runner.modo],-100f,0);
			Runner.maxy[Runner.modo]=EditorGUILayout.Slider("Limite Superior",Runner.maxy[Runner.modo],0f,100f);
			EditorGUILayout.EndHorizontal();

			if (Runner.miny[Runner.modo]<0 || Runner.maxy[Runner.modo]>0)
			{
				Runner.offsety[Runner.modo]=EditorGUILayout.Slider("Desfase en Y",Runner.offsety[Runner.modo],Runner.miny[Runner.modo],Runner.maxy[Runner.modo]);
			}
			
		}
		EditorGUILayout.EndVertical();
    }
	
}
