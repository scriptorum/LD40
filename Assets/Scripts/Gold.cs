using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
	void Awake()
	{
		Game.instance.level.numBags++;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
			PickupGold();
	}

	void PickupGold()
	{
		Game.instance.level.numBags--;
		Inventory.instance.Pickup(this);
		Destroy(gameObject);
	}
}