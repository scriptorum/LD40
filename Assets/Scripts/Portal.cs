using System.Collections;
using System.Collections.Generic;
using Spewnity;
using UnityEngine;

public class Portal : MonoBehaviour
{
	public TweenManager tm;
	private CircleCollider2D col;

	void Awake()
	{
		tm.ThrowIfNull();
		gameObject.SelfAssign(ref col);
		col.enabled = false;
	}

	void Start()
	{
	}

	public void Appear()
	{
		col.enabled = true;
		tm.Play("appear");
		SoundManager.instance.Play("portal");
	}

	public void Disappear()
	{
		SoundManager.instance.Play("portalbye");
		col.enabled = false;
		tm.Play("disappear");
	}
}