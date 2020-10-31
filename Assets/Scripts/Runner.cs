using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Runner : MonoBehaviour {
	public int modo = 0;
	public float[] speed = {5f,5f,5f};
	public float[] jump = {20f,20f,0f};
	public bool onjump = false;
	public bool enPiso;
	public float[] gravity = {9.8f,9.8f,0f};
	public Rigidbody2D rb;
	public Animator anim;
	private SpriteRenderer spr;

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
		rb.gravityScale = gravity[modo];
		enPiso = Physics2D.OverlapCircle(new Vector2(gameObject.transform.position.x,(gameObject.transform.position.y)-1.6f*gameObject.transform.localScale.y),0.25f,1<<8);
		rb.velocity = new Vector2(Input.GetAxis("Horizontal")*speed[modo],rb.velocity.y);
		switch (modo)
		{
			case 0:	if (Input.GetButton("Jump") && enPiso) rb.velocity = new Vector2(rb.velocity.x,jump[modo]);
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
	public string[] modes = new string[]{"Scroll Lateral","Infite Runner","TopDown"};
    public override void OnInspectorGUI()
    {
        var Runner = target as Runner;
		EditorGUILayout.LabelField("Tipo de Movimiento");
		Runner.modo = EditorGUILayout.Popup(Runner.modo,modes);
		Runner.speed[Runner.modo] = EditorGUILayout.Slider("Velocidad",Runner.speed[Runner.modo],0f,30f);
		Runner.jump[Runner.modo] = EditorGUILayout.Slider("Fuerza de Salto",Runner.jump[Runner.modo],0f,50f);
		Runner.gravity[Runner.modo] = EditorGUILayout.Slider("Gravedad",Runner.gravity[Runner.modo],0f,9.8f);
    }
}
