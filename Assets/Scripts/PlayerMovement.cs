using System;
using System.Collections;
using System.Collections.Generic;
using Spewnity;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float MAX_SPEED = 5f;
    private float speed = 100f;
	private Rigidbody2D rb;
	private SpriteRenderer sr;

	void Awake()
	{
		gameObject.SelfAssign(ref rb);
		gameObject.SelfAssign(ref sr);
	}

	// Use this for initialization
	void Update()
	{
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");

		rb.AddForce(Vector2.right * x * speed);
		if(Mathf.Abs(rb.velocity.x) > MAX_SPEED) 
			rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * MAX_SPEED, rb.velocity.y);

		if((sr.flipX && x > 0) || (!sr.flipX && x < 0))
			sr.flipX = !sr.flipX;

		if(Input.GetKey(KeyCode.R))
			Reset();


	}

    private void Reset()
    {
		rb.velocity = Vector3.zero;
        transform.localPosition = new Vector3(0,3,0);
    }
}