﻿using UnityEngine;
using System.Collections;

public class enemyMove : MonoBehaviour {
	public GameObject[] targets;
	public float speed = 10;
	public float force = 2;
	public float range = 2;
	public float atkRange = 0.5f;
	public int jumps = 2;
	public bool canjump = false;
	public Animator anim;
	//Why does a C programmer need glasses? Because he cant C#! hahahahaha
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void Update () {
		/*
		if (Input.GetKey (KeyCode.W)) {
			speed = 2;			
		} else {
			speed = 1;
		}
		*/

	}

	void FixedUpdate () {
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		targets = GameObject.FindGameObjectsWithTag("Good");
		float highestWeight = 0;
		GameObject bestMatch = null;
		for (int i = 0; i < targets.Length; i++) {
			GameObject target = targets [i];
			if (Vector3.Distance (target.transform.position, transform.position) < range) { //if target within range
				float weight = Vector3.Distance (target.transform.position, transform.position);
				if (weight > highestWeight) {
					highestWeight = weight;
					bestMatch = target;
				}
			}
		}
		//Debug.Log(GetComponent<Rigidbody2D>().velocity.magnitude);
		if(bestMatch != null) {
			if(Vector3.Distance (bestMatch.transform.position, transform.position) < atkRange) {
				anim.SetTrigger("atk");
			} else {
				speed = 1;
				float h = 0;
				Vector3 posBM = bestMatch.transform.position;
				Vector3 pos = transform.position;
				if(pos.x > posBM.x) {
					transform.localScale = new Vector3(1f,1f,1f);
					h = Vector2.left.x;
				} else {
					transform.localScale = new Vector3(-1f,1f,1f);
					h = Vector2.right.x;
				}
				Vector3 v = rb.velocity;
				v.x = h * speed;
				rb.velocity = v; 
			
			}
		}
		/*
		if (Input.GetKey (leftKey)) { //move left
			transform.localScale = new Vector3(1f,1f,1f);
			if (Input.GetKey (runKey)) { 
				speed = 2;			
			} else { 
				speed = 1;
			}

			float h = Vector2.left.x;
			Vector3 v = rb.velocity;
			v.x = h * speed;
			rb.velocity = v; 

		} else if (Input.GetKey (rightKey)) { //move right
			transform.localScale = new Vector3(-1f,1f,1f);
			if (Input.GetKey (runKey)) {
				speed = 2;			
			} else { 
				speed = 1;
			}
			float h = Vector2.right.x;
			Vector3 v = rb.velocity;
			v.x = h * speed;
			rb.velocity = v; 

		} else {
			speed = 0;
		}
		anim.SetFloat ("speed", speed);
		if (Input.GetKeyDown (jumpKey)) { //jump
			Debug.Log("jump!");
			if (jumps > 0) {
				anim.SetTrigger ("jump");
				rb.velocity = new Vector2 (0, 0);
				rb.velocity += new Vector2 (0, force + speed);
				jumps--;
			}
		}
		if (Input.GetMouseButton(1)) {
			anim.SetBool ("aiming", true);
		} else {
			anim.SetBool ("aiming", false);
		}
		if (Input.GetMouseButton (0)) {
			anim.SetTrigger ("atk");
		}
		*/
	}
	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.name == "floor") {
			jumps = 2;
		}
	}
}
