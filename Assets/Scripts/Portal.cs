using System.Collections;
using System.Collections.Generic;
using Spewnity;
using UnityEngine;

public class Portal : MonoBehaviour
{
	public TweenManager tm;
	public CircleCollider2D col;

	void Awake()
	{
		tm.ThrowIfNull();
		gameObject.SelfAssign(ref col);
	}

	void Start()
	{
		Appear();
	}

	public void Appear()
	{
		col.enabled = true;
		tm.Play("appear");
		SoundManager.instance.Play("portal");
	}

	public void Disappear()
	{
		col.enabled = false;
		tm.Play("disappear");

	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag != "Player")
			return;

		Debug.Log("Player entered the portal!");

		SoundManager.instance.Play("portal");
		Disappear();
	}
}