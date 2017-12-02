using System;
using System.Collections;
using System.Collections.Generic;
using Spewnity;
using UnityEngine;

public class GoldIcon : MonoBehaviour
{
	void Awake()
	{
		Empty();
		Inventory.instance.RegisterSlot(this);;
	}

	internal void SetContent(Gold gold)
	{
		gameObject.SetActive(true);
		// TODO Show gold amount
	}

	internal void Empty()
	{
		gameObject.SetActive(false);
	}
}