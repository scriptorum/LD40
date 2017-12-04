using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Spewnity;

public class Message : MonoBehaviour 
{
	private TextMeshPro tmp;

	void Awake()
	{
		gameObject.SelfAssign(ref tmp);
	}

	public void SetMessage(string s)
	{
		if(s.IsEmpty())
			return;

		tmp.text = s;
		TweenManager.instance.PlayCompound("showText");
	}

}
