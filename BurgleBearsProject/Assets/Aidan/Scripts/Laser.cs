using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
	[SerializeField] private AlarmGuardSpawner spawner = null;
	[SerializeField] private float range = 500f;
	private LineRenderer lr;
	private Vector3 endPoint = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
		lr = transform.Find("Graphics").GetComponent<LineRenderer>();
		if (lr == null)
		{
			Debug.Log("Line renderer for laser is missing!");
		}
    }

    // Update is called once per frame
    void Update()
    {
		RaycastHit hit;
		endPoint = transform.forward * range;
		if (Physics.Raycast(transform.position, transform.forward, out hit))
		{
			endPoint = transform.InverseTransformPoint(hit.point);
			if (hit.collider)
			{
				if (hit.collider.tag == "Player")
				{
					// Player has touched the laser, alarm the guards
					spawner.Spawn();
				}
				else
				{
					lr.SetPosition(1, hit.point);
				}
			}
		}
		lr.SetPosition(1, endPoint);

	}
}
