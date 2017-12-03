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
	private const float WEIGHT_PENALTY = 20f; // Higher numbers is more forgiving, do not go below max inventory size
	private const float WEIGHT_PENALTY_TO_MAX_SPEED = 0.4f;
	private const float maxSpeed = 5f;
	private float walkForce = 300f;
	private float floatForce = 50f;
	private float jumpForce = 525f;
	private float lastOnGround = 0;
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
		if(Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
			lastOnGround = Time.realtimeSinceStartup;
	}

	void FixedUpdate()
	{
		float x = Input.GetAxis("Horizontal");
		int weight = Inventory.instance.GetGoldWeight();

		bool onGround = (Time.realtimeSinceStartup - lastOnGround) < 0.1f;
		if (onGround && jumping && rb.velocity.y < 0.025f)
		{
			rb.velocity = new Vector3(rb.velocity.x, 0f);
            float actualJumpForce = jumpForce - weight * WEIGHT_PENALTY;
			rb.AddForce(new Vector2(0f, actualJumpForce));
			SoundManager.instance.PlayAs("jump", 1.2f - weight * 0.1f, 0.8f);
			onGround = false;
		}

	

		float curForce = onGround ? walkForce - weight * WEIGHT_PENALTY : floatForce;
		rb.AddForce(Vector2.right * x * curForce);

		if (Mathf.Abs(rb.velocity.x) > maxSpeed)
			rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed - weight * WEIGHT_PENALTY_TO_MAX_SPEED, rb.velocity.y);

		if ((sr.flipX && x > 0) || (!sr.flipX && x < 0))
			sr.flipX = !sr.flipX;
	}

	private void Reset()
	{
		rb.velocity = Vector3.zero;
		transform.localPosition = new Vector3(0, 3, 0);
	}
}