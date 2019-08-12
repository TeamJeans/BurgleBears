using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AlarmGuardSpawner : MonoBehaviour
{
	private Transform spawnPoints;
	private ObjectPooling alarmGuardPool;
	private List<GameObject> activeGuards = new List<GameObject>();
	private bool spawned = false;

	private void Awake()
	{
		spawnPoints = transform.Find("SpawnPoints");
		if (spawnPoints == null)
		{
			Debug.Log("Alarm guard spawner has no child with the name 'SpawnPoints'!");
		}

		alarmGuardPool = transform.Find("AlarmGuardPool").GetComponent<ObjectPooling>();
		if (alarmGuardPool == null)
		{
			Debug.Log("Alarm guard spawner has no child with the name 'AlarmGuardPool'!");
		}
	}

	private void Update()
	{
		#region TESTING
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Spawn();
		}

		if (Input.GetKeyDown(KeyCode.X))
		{
			DespawnAll();
		}
		#endregion

		if (spawned)
		{

		}
	}

	public void Spawn()
	{
		if (!spawned)
		{
			spawned = true;
			foreach (Transform t in spawnPoints)
			{
				GameObject guardholder = alarmGuardPool.RetrieveInstance();
				GameObject guard = guardholder.transform.Find("AlarmGuard").gameObject;
				guard.transform.position = t.position;
				guard.GetComponent<AIDestinationSetter>().target = guard.GetComponent<PlayerSpotting>().Player;
				guard.GetComponent<AIDestinationSetter>().enabled = true;
				guard.GetComponent<PlayerSpotting>().DetectionEyeBar.FillHalfBar();
				guard.GetComponent<PlayerSpotting>().Spawner = this;
				activeGuards.Add(guardholder);
			}
		}
	}

	public void DespawnAll()
	{
		if (spawned)
		{
			spawned = false;
			foreach (GameObject g in activeGuards)
			{
				alarmGuardPool.DevolveInstance(g);
			}
			activeGuards.Clear();
		}
	}

	public void Despawn(GameObject g)
	{
		alarmGuardPool.DevolveInstance(g);
	}
}
