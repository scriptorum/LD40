using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spewnity;

public class PlayerPortalInteraction : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag != "portal")
			return;

		int bagsInLevel = Game.instance.level.numBags;
		List<Gold> bags = Inventory.instance.TakeBags();

		// If player has bags in inventory but there are more bags in the level, drop off the bags
		// If player has bags in inventory and there are no bags left in the level, drop off the bags, and end the level
		if(bags.Count > 0)
			SoundManager.instance.Play("kaching");

		if(bagsInLevel <= 0)
			Game.instance.Escape();

		// Otherwise taunt player
	}	
}
