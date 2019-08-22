using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AlarmController : MonoBehaviour
{
	[SerializeField] private AlarmGuardSpawner spawner = null;
	private GameObject scaredGuard = null;
	private bool alarmActivated = false;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "ScaredGuard")
		{
			spawner.Spawn();
			alarmActivated = true;
			scaredGuard = other.gameObject;
			scaredGuard.GetComponentInParent<PlayerSpotting>().ActivatedAlarm = true;
		}
	}

	private void Awake()
	{
		if (spawner == null)
		{
			Debug.Log("No alarm guard spawner found!");
		}
	}

	private void Update()
	{
		if (!spawner.Spawned && alarmActivated)
		{
			alarmActivated = false;
			Debug.Log("Alarm deactivated!");
			scaredGuard.GetComponentInParent<PlayerSpotting>().ActivatedAlarm = false;
			scaredGuard = null;
		}
	}
}
