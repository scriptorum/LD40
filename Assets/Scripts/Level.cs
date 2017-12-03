using System;
using System.Collections;
using System.Collections.Generic;
using Spewnity;
using UnityEngine;

public class Level : MonoBehaviour
{
	public GameObject platformPrefab;
	public GameObject goldPrefab;

	public int numBags = 0;
	public int level = 1;

	public LevelData data;

	#if UNITY_EDITOR
	void OnValidate()
	{
		if(Application.isPlaying)
		{
			Refresh();			
		}
	}
	#endif

	public void Load()
	{
		string path = "level" + level.ToString();
		transform.GetChild("Platforms").DestroyChildren();
		transform.GetChild("Gold").DestroyChildren();
		TextAsset asset = Resources.Load(path) as TextAsset;
		data = JsonUtility.FromJson<LevelData>(asset.text);
		ProcessLevelData();
	}

	public void Refresh()
	{
		transform.GetChild("Platforms").DestroyChildren();
		transform.GetChild("Gold").DestroyChildren();
		ProcessLevelData();
	}

	public void ProcessLevelData()
	{
		Transform portal = transform.GetChild("Portal");
		Transform platforms = transform.GetChild("Platforms");
		Transform gold = transform.GetChild("Gold");

		portal.position = new Vector3(data.portal.x, data.portal.y);

		int i = 0;
		foreach (PlatformData pd in data.platforms)
		{
			GameObject pgo = platformPrefab.CreateChild(platforms);
			pgo.transform.localPosition = new Vector3(pd.position.x, pd.position.y);
			pgo.GetComponent<SpriteRenderer>().size = pd.size;
			BoxCollider2D pgocol = pgo.GetComponent<BoxCollider2D>();
			pgocol.size = pd.size;
			pgocol.offset = new Vector2(pgocol.offset.x, (pd.size.y - pd.size.y) / 2);
			pgo.name = "platform" + i++;
		}

		numBags = 0;
		i = 0;		
		foreach (GoldData gd in data.gold)
		{
			GameObject ggo = goldPrefab.CreateChild(gold);
			ggo.transform.localPosition = new Vector3(gd.position.x, gd.position.y);
			ggo.GetComponent<Gold>().weight = gd.weight;
			numBags++;
			ggo.name = "gold" + i++;
		}
	}

#if UNITY_EDITOR
	public void Save()
	{		
		string path = "Assets/Resources/" + "level" + level.ToString() + ".json";
		Debug.Log("Save level:" + path);
		// System.IO.File.Delete(path);
		System.IO.StreamWriter sw = System.IO.File.CreateText(path);
		string json = JsonUtility.ToJson(data);
		sw.Write(json);
		sw.Close();

		UnityEditor.AssetDatabase.Refresh();
	}
#endif

}

[System.Serializable]
public class LevelData
{
	public int timer = 30;
	public string message;
	public bool specialStart = false;
	public List<PlatformData> platforms;
	public List<GoldData> gold;
	public Vector2 portal;
}

[System.Serializable]
public struct PlatformData
{
	public Vector2 position;
	public Vector2 size;
}

[System.Serializable]
public struct GoldData
{
	public Vector2 position;
	public int weight;
}