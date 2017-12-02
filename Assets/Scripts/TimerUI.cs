using System;
using System.Collections;
using System.Collections.Generic;
using Spewnity;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
	public static TimerUI instance;
	public TextMeshPro text;
	public float time;

	void Awake()
	{
		text.ThrowIfNull();
		time = 30.0f;
		StopTimer();
	}

	void Update()
	{
		time -= Time.deltaTime;
		UpdateView();
	}

	private void UpdateView()
	{
		if (time < 0) time = 0;
		text.text = System.String.Format("{0:F2}", time);
	}

	internal void SetTime(int timer)
	{
		time = timer;
		StopTimer();
		UpdateView();
	}

	public void StopTimer()
	{
		this.enabled = false;
	}

	public void StartTimer()
	{
		this.enabled = true;
	}

}