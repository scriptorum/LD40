using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
	public int weight = 1;

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