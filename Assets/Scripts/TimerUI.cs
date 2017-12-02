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
	}

	void Update()
	{
		time -= Time.deltaTime;
		if (time < 0) time = 0;
		text.text = System.String.Format("{0:F2}", time);
	}
}