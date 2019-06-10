using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPathPoints : MonoBehaviour
{
	private void OnDrawGizmos()
	{
		Vector3 startPos = transform.GetChild(0).position;
		Vector3 previousPos = startPos;
		Gizmos.color = Color.red;
		foreach(Transform waypoint in transform)
		{
			Gizmos.DrawSphere(waypoint.position, .3f);
			Gizmos.DrawLine(previousPos, waypoint.position);
			previousPos = waypoint.position;
		}
		Gizmos.DrawLine(previousPos, startPos);
	}
}
