using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Spewnity.SoundManager.instance.Play("song");
	}
	
}
