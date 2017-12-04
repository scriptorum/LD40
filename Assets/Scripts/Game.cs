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
	public Message message;
	public ParticleSystem playerPS;

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
		Spewnity.SoundManager.instance.Play("song");
		Reset();
	}

	private void Reset()
	{
		level.Load();
		Inventory.instance.Reset();
		player.SetActive(false);
		portal.Appear();
		timer.gameObject.SetActive(level.data.timer > 0);
		timer.SetTime(level.data.timer);
		message.SetMessage(level.data.message);
		aq.Delay(0.9f);
		aq.Add(() =>
		{
			if (level.data.specialStart)
				player.transform.position = new Vector3(-3, -3.74626f, 0);
			else player.transform.position = portal.transform.position;
			player.SetActive(true);
			playerPS.Play();
			if (timer.gameObject.activeSelf) timer.StartTimer();
		});
		aq.Run();
	}

	public void TimeOut()
	{
		timer.gameObject.SetActive(false);
		portal.Disappear();
		message.SetMessage("You Ran Out Of Time");
		aq.Delay(2f);
		aq.Add(() => Reset());
		aq.Run();
	}

	public void Escape()
	{
		if (timer.isActiveAndEnabled)
			timer.StopTimer();
		player.SetActive(false);
		portal.Disappear();
		aq.Delay(1f);
		aq.Add(() => NextLevel());
		aq.Run();
	}

	private void NextLevel()
	{
		SetLevel(level.level + 1);
	}

	void Update()
	{
#if UNITY_EDITOR
		if (Input.GetKeyDown(KeyCode.L))
			level.Load();
		if (Input.GetKeyDown(KeyCode.S))
			level.Save();
		if (Input.GetKeyDown(KeyCode.LeftBracket))
			SetLevel(level.level - 1);
		if (Input.GetKeyDown(KeyCode.RightBracket))
			SetLevel(level.level + 1);

#endif
		if (Input.GetKeyDown(KeyCode.R))
			Reset();
	}

	private void SetLevel(int level)
	{
		this.level.level = level;
		Reset();
	}
}