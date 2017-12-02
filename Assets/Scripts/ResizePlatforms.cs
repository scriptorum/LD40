using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spewnity;

// Maintains the collider shape to match the shape of the prefab
public class ResizePlatforms : MonoBehaviour
{
	private SpriteRenderer sr;
	private BoxCollider2D col;

	void Awake()
	{
		gameObject.SelfAssign(ref sr);
		gameObject.SelfAssign(ref col);
	}

	void Start()
	{
		sr.size = transform.localScale;
		col.size = new Vector2(col.size.x * sr.size.x, col.size.y);
		col.offset = new Vector2(col.offset.x, (sr.size.y - col.size.y) / 2);
		transform.localScale = Vector3.one;
	}
}