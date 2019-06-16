using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerSpotting : MonoBehaviour
{
	[SerializeField] private Light spotLight = null;
	[SerializeField] private float viewDistance = 0f;
	[SerializeField] private LayerMask viewMask;
	[SerializeField] private DetectionBar detectionBar = null;
	[SerializeField] private float detectionRate = 4f;

	private float viewAngle;
	Transform player;
	Color originalSpotLightColor;

	enum GuardType
	{
		PATROL_GUARD,
		ALARM_GUARD
	}

	[SerializeField] private GuardType guardType = GuardType.PATROL_GUARD; // Patrol guard set by default

	private Patrol patrol;
	private AIDestinationSetter destination;

	private void Awake()
	{
		if (guardType == GuardType.PATROL_GUARD)
		{
			// Find the patrol script on this object
			patrol = GetComponent<Patrol>();
			if (patrol == null)
			{
				Debug.Log("Patrol not found!");
			}
		}

		// Find the AIDestinationSetter script on this object
		destination = GetComponent<AIDestinationSetter>();
		if (destination == null)
		{
			Debug.Log("Destination not found!");
		}

		// Find the player
		player = GameObject.FindGameObjectWithTag("Player").transform;
		if (player == null)
		{
			Debug.Log("Player not found!");
		}
	}

	// Start is called before the first frame update
	void Start()
    {
		viewAngle = spotLight.spotAngle;
		originalSpotLightColor = spotLight.color;
	}

    // Update is called once per frame
    void Update()
    {
		if (CanSeePlayer())
		{
			detectionBar.TimeForBarToFill = (viewDistance - (viewDistance - Vector3.Distance(transform.position, player.position))) * (1/detectionRate);
			detectionBar.FillBar();
			switch (guardType)
			{
				case GuardType.PATROL_GUARD:
					patrol.enabled = false;
					break;
				case GuardType.ALARM_GUARD:
					break;
				default:
					break;
			}

			if (detectionBar.Full)
			{
				ChasePlayer();
			}
		}
		else
		{
			detectionBar.DepleteBar();

			if (detectionBar.Depleted)
			{
				switch (guardType)
				{
					case GuardType.PATROL_GUARD:
						GoBackToPatrol();
						break;
					case GuardType.ALARM_GUARD:
						break;
					default:
						break;
				}
			}
		}
    }

	private bool CanSeePlayer()
	{
		if (Vector3.Distance(transform.position, player.position) < viewDistance)
		{
			Vector3 dirToPlayer = (player.position - transform.position).normalized;
			float angleBetweenGuardAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);
			if (angleBetweenGuardAndPlayer < viewAngle/2f)
			{
				if (!Physics.Linecast(transform.position, player.position, viewMask))
				{
					return true;
				}
			}
		}
		return false;
	}

	private void ChasePlayer()
	{
		spotLight.color = Color.red;
		destination.enabled = true;
	}

	private void GoBackToPatrol()
	{
		spotLight.color = originalSpotLightColor;
		destination.enabled = false;
		patrol.enabled = true;
	}
}
