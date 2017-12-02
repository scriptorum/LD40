using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spewnity;

public class SpawnSeries : MonoBehaviour {

	public GameObject prefab;
	public int numberToSpawn = 1;
	public Vector2 spawnOffset = new Vector2(1, 0);

	private int spawnCount = 0;

	void Start ()
	{
		for(int i = 0; i < numberToSpawn; i++)
			Spawn();
	}

	public void Spawn()
	{
		prefab.CreateChild(transform, spawnOffset * spawnCount); 
		spawnCount++;
	}

	public void Reset()
	{
		spawnCount = 0;
	}
}
