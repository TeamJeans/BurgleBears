using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
	private LineRenderer lr;
	private float range = 500f;
	private Vector3 endPoint;

    // Start is called before the first frame update
    void Start()
    {
		lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		//lr.SetPosition(0, transform.position);
		RaycastHit hit;
		endPoint = transform.forward * range;
		if (Physics.Raycast(transform.position, transform.forward, out hit))
		{
			endPoint = transform.InverseTransformPoint(hit.point);
			if (hit.collider)
			{
				lr.SetPosition(1, hit.point);
			}
		}
		lr.SetPosition(1, endPoint);

	}
}
