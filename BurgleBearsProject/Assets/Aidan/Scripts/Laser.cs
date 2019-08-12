using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
	[SerializeField] private AlarmGuardSpawner spawner = null;
	[SerializeField] Transform pathTransform = null;
	[SerializeField] private float range = 500f;
	[SerializeField] private float disabledTime = 0f;
	[SerializeField] private float movingLaserSpeed = 0f;
	private float elapsedTime = 0f;
	private bool laserIsActive = true;
	private LineRenderer lr;
	private Vector3 endPoint = Vector3.zero;

	// Variables for moving laser
	private int currentNode = 0;
	private Vector3 targetPos = Vector3.zero;
	private int noOfNodes = 0;

	// Variables for timed lasers
	[SerializeField] private Material alarmLazerMat = null;
	[SerializeField] private Material safeLazerMat = null;
	[SerializeField] private float colourChangeTime = 0f;
	private float elapsedColourChangeTime = 0f;
	private bool colourChanged = false;

	enum LaserType
	{
		STATIC,
		MOVING,
		TIMED,
		TIMED_AND_MOING
	}
	[SerializeField] private LaserType type = LaserType.STATIC;

	private void OnDrawGizmos()
	{
		Vector3 startPos = pathTransform.GetChild(0).position;
		Vector3 previousPos = startPos;
		Gizmos.color = Color.red;
		foreach (Transform waypoint in pathTransform)
		{
			Gizmos.DrawSphere(waypoint.position, .3f);
			Gizmos.DrawLine(previousPos, waypoint.position);
			previousPos = waypoint.position;
		}
		Gizmos.DrawLine(previousPos, startPos);
	}

	void Awake()
    {
		lr = transform.Find("Graphics").GetComponent<LineRenderer>();
		if (lr == null)
		{
			Debug.Log("Line renderer for laser is missing!");
		}
    }

	private void Start()
	{
		// Get the number of nodes in the path
		noOfNodes = 0;
		foreach (Transform t in pathTransform)
		{
			noOfNodes++;
		}
	}

	// Update is called once per frame
	void Update()
	{
		switch (type)
		{
			case LaserType.STATIC:
				StaticLaser();
				break;
			case LaserType.MOVING:
				MovingLaser();
				break;
			case LaserType.TIMED:
				TimedLaser();
				break;
			case LaserType.TIMED_AND_MOING:
				TimedAndMovingLaser();
				break;
			default:
				break;
		}
	}

	private void StaticLaser()
	{
		RaycastHit hit;
		endPoint = transform.forward * range;

		if (laserIsActive)
		{
			if (Physics.Raycast(transform.position, transform.forward, out hit))
			{
				endPoint = transform.InverseTransformPoint(hit.point);
				if (hit.collider)
				{
					if (hit.collider.tag == "Player")
					{
						// Player has touched the laser, alarm the guards
						spawner.Spawn();
						laserIsActive = false;
					}
					else
					{
						lr.SetPosition(1, hit.point);
					}
				}
			}
			lr.SetPosition(1, endPoint);
		}
		else
		{
			lr.SetPosition(1, new Vector3(0, 0, 0));
			elapsedTime += Time.deltaTime;
			if (elapsedTime >= disabledTime)
			{
				elapsedTime = 0f;
				laserIsActive = true;
			}

		}
	}

	private void MovingLaser()
	{
		StaticLaser();

		targetPos = pathTransform.GetChild(currentNode).position;

		// Calulate the velocity using the direction of the target and the movementSpeed
		Vector3 velocity = Vector3.zero;
		velocity = (targetPos - transform.parent.gameObject.transform.position).normalized * movingLaserSpeed;
		Debug.Log(targetPos);

		// Move laser towards the target position
		transform.parent.gameObject.GetComponent<Rigidbody>().MovePosition(transform.parent.gameObject.GetComponent<Rigidbody>().position + velocity * Time.deltaTime);

		// If the laser in close enough to the target change to the next target
		if (Vector3.Distance(targetPos, transform.parent.gameObject.transform.position) < .2f)
		{
			if ((currentNode + 1) < noOfNodes)
			{
				currentNode++;
			}
			else
			{
				currentNode = 0;
			}
		}
	}

	private void TimedLaser()
	{
		RaycastHit hit;
		endPoint = transform.forward * range;

		if (laserIsActive)
		{
			if (Physics.Raycast(transform.position, transform.forward, out hit))
			{
				endPoint = transform.InverseTransformPoint(hit.point);
				if (hit.collider)
				{
					if (hit.collider.tag == "Player")
					{
						if (!colourChanged)
						{
							// Player has touched the laser, alarm the guards
							spawner.Spawn();
							laserIsActive = false;
						}
					}
					else
					{
						lr.SetPosition(1, hit.point);
					}
				}
			}
			lr.SetPosition(1, endPoint);
		}
		else
		{
			lr.SetPosition(1, new Vector3(0, 0, 0));
			elapsedTime += Time.deltaTime;
			if (elapsedTime >= disabledTime)
			{
				elapsedTime = 0f;
				laserIsActive = true;
			}

		}

		// Change the colour when time has passed
		elapsedColourChangeTime += Time.deltaTime;
		if (elapsedColourChangeTime >= colourChangeTime)
		{
			elapsedColourChangeTime = 0;
			colourChanged = !colourChanged;
		}

		if (colourChanged)
		{
			lr.material = safeLazerMat;
		}
		else
		{
			lr.material = alarmLazerMat;
		}
	}

	private void TimedAndMovingLaser()
	{
		TimedLaser();

		targetPos = pathTransform.GetChild(currentNode).position;

		// Calulate the velocity using the direction of the target and the movementSpeed
		Vector3 velocity = Vector3.zero;
		velocity = (targetPos - transform.parent.gameObject.transform.position).normalized * movingLaserSpeed;

		// Move laser towards the target position
		transform.parent.gameObject.GetComponent<Rigidbody>().MovePosition(transform.parent.gameObject.GetComponent<Rigidbody>().position + velocity * Time.deltaTime);

		// If the laser in close enough to the target change to the next target
		if (Vector3.Distance(targetPos, transform.parent.gameObject.transform.position) < .2f)
		{
			if ((currentNode + 1) < noOfNodes)
			{
				currentNode++;
			}
			else
			{
				currentNode = 0;
			}
		}
	}
}
