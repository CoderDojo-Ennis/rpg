﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlast : MonoBehaviour {

	void Start ()
	{
		GetComponent<Rigidbody2D>().AddForce(this.transform.rotation * new Vector3(0, -5, 0),ForceMode2D.Impulse);
	}
	void Update()
	{
		Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
		float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
		
		transform.rotation = Quaternion.AngleAxis (angle+90 , Vector3.forward);
	}
	void OnCollisionEnter2D()
	{
		GameObject.Destroy(this.gameObject);
	}
}