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

    private void StartLevel()
    {
		player.SetActive(false);
		portal.Appear();
		aq.Delay(0.9f);
		aq.Add(() => 
		{
			player.transform.position = portal.transform.position;
			player.SetActive(true);
		});
		aq.Run();
    }

    public void Escape()
    {
        player.SetActive(false);
		portal.Disappear();
    }
}