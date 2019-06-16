using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGuardSpawnPoints : MonoBehaviour
{
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		foreach (Transform waypoint in transform)
		{
			Gizmos.DrawSphere(waypoint.position, .5f);
		}
	}
}
