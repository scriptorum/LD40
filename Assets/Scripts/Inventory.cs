using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public static Inventory instance;

	public List<Gold> contents;

	void Awake()
	{
		instance = this;
		contents = new List<Gold>();
	}

	public void Pickup(Gold g)
	{
		contents.Add(g);
	}
}