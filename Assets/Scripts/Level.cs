using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spewnity;

public class Level : MonoBehaviour
{
	public int numBags = 0; // automatically populated 
	public int timer = 30;

	public string ToJson()
	{
		string result = "{";
		string comma = "";
		result += "\"platform\": [";
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("platform"))
		{
			result += comma;
			comma = ",";
			result += "{";
			result += "\"position\": " + JsonUtility.ToJson(go.transform.localPosition) + ",";
			result += "\"size\": " + JsonUtility.ToJson(go.GetComponent<SpriteRenderer>().size);			
 			result += "}";
		}
		result += "],";

		comma = "";
		result += "\"gold\": [";
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("gold"))
		{
			result += comma;
			comma = ",";
			result += "{";
			result += "\"position\": " + JsonUtility.ToJson(go.transform.localPosition);
			result += "}";
		}
		result += "],";

		result += "\"portal\": " + JsonUtility.ToJson(GameObject.FindGameObjectWithTag("portal").transform.localPosition);

		result += "}";

		return result;
	}
}