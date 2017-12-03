using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameGizmo : MonoBehaviour
{
	void OnDrawGizmos()
	{
		UnityEditor.Handles.Label(transform.position, transform.name);
	}
}