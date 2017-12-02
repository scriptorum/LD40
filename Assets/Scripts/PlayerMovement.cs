using System;
using System.Collections;
using System.Collections.Generic;
using Spewnity;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Transform groundCheck;
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private const float maxSpeed = 5f;
	private float walkForce = 200f;
	private float floatForce = 50f;
	private float jumpForce = 400f;
	private bool onGround = false;
	private bool jumping = false;

    void Awake()
	{
		gameObject.SelfAssign(ref rb);
		gameObject.SelfAssign(ref sr);
		groundCheck.ThrowIfNull();
	}

	void Update()
	{
		jumping = Input.GetKey(KeyCode.Space);
		onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
	}

	void FixedUpdate()
	{
		float x = Input.GetAxis("Horizontal");

		if (onGround && jumping)
		{
			rb.AddForce(new Vector2(0f, jumpForce));
			onGround = false;
		}

	
		float curForce = onGround ? walkForce : floatForce;
		rb.AddForce(Vector2.right * x * curForce);

		if (Mathf.Abs(rb.velocity.x) > maxSpeed)
			rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);

		if ((sr.flipX && x > 0) || (!sr.flipX && x < 0))
			sr.flipX = !sr.flipX;

		if (Input.GetKey(KeyCode.R))
			Reset();
	}

	private void Reset()
	{
		rb.velocity = Vector3.zero;
		transform.localPosition = new Vector3(0, 3, 0);
	}
}