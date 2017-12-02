using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
			PickupGold();
	}

	void PickupGold()
	{
		Inventory.instance.Pickup(this);
		Destroy(gameObject);
	}
}