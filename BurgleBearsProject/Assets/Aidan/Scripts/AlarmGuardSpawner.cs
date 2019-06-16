using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmGuardSpawner : MonoBehaviour
{
	private Transform spawnPoints;
	private ObjectPooling alarmGuardPool;
	private List<GameObject> activeGuards = new List<GameObject>();

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
			Despawn();
		}
		#endregion
	}

	public void Spawn()
	{
		foreach(Transform t in spawnPoints)
		{
			GameObject guard = alarmGuardPool.RetrieveInstance();
			guard.transform.position = t.position;
			activeGuards.Add(guard);
		}
	}

	public void Despawn()
	{
		foreach (GameObject g in activeGuards)
		{
			alarmGuardPool.DevolveInstance(g);
		}
		activeGuards.Clear();
	}
}
