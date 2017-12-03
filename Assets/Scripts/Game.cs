using System;
using System.Collections;
using System.Collections.Generic;
using Spewnity;
using UnityEngine;

public class Game : MonoBehaviour
{
	public static Game instance;
	public Portal portal;
	public TimerUI timer;
	public GameObject player;
	public Level level;

	private ActionQueue aq;

	void Awake()
	{
		instance = this;
		portal.ThrowIfNull();
		timer.ThrowIfNull();
		player.ThrowIfNull();
		aq = gameObject.AddComponent<ActionQueue>();
	}

	void Start()
	{
		StartLevel();
	}

	private void Reset()
	{
		RestartLevel();
	}

	private void StartLevel()
	{
		level.Load();
		RestartLevel();
	}

	private void RestartLevel()
	{
		Inventory.instance.Reset();
		player.SetActive(false);
		portal.Appear();
		timer.SetTime(level.data.timer);
		aq.Delay(0.9f);
		aq.Log("Revealing player");
		aq.Add(() =>
		{
			player.transform.position = portal.transform.position;
			player.SetActive(true);
			timer.StartTimer();
		});
		aq.Run();
	}

	public void Escape()
	{
		timer.StopTimer();
		player.SetActive(false);
		portal.Disappear();
		aq.Delay(1f);
		aq.Log("Escaped! Loading next level");
		aq.Add(() => NextLevel());
		aq.Run();
	}

	private void NextLevel()
	{
		StartLevel();
	}

	void Update()
	{
#if UNITY_EDITOR
		if (Input.GetKeyDown(KeyCode.L))
			level.Load();
		if (Input.GetKeyDown(KeyCode.S))
			level.Save();
#endif
		if (Input.GetKeyDown(KeyCode.R))
			Reset();
	}
}