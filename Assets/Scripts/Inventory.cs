using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spewnity;
using System;

public class Inventory : MonoBehaviour
{
	public static Inventory instance;

	public List<Gold> contents;
	public List<GoldIcon> slots;

	void Awake()
	{
		instance = this;
		contents = new List<Gold>();
		slots = new List<GoldIcon>();
	}

    public void RegisterSlot(GoldIcon goldIcon)
    {
        slots.Add(goldIcon);
    }

    public void Pickup(Gold g)
    {
        SoundManager.instance.PlayAs("pickup", 1.2f - Inventory.instance.GetGoldWeight() * 0.1f, 0.8f);
        contents.Add(g);
        UpdateSlots();
    }

    public List<Gold> TakeBags()
    {
        List<Gold> temp = contents;
        contents = new List<Gold>();
        UpdateSlots();
        return temp;
    }

    private void UpdateSlots()
    {
        for (int i = 0; i < slots.Count; i++)
        {
			if(i < contents.Count)
				slots[i].SetContent(contents[i]);
			else slots[i].Empty();
        }
    }

    public void Reset()
    {
        contents.Clear();
        UpdateSlots();
    }

    public int GetGoldWeight()
    {
        return contents.Count; // TODO Bags of different weight
    }
}