using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerSpotting : MonoBehaviour
{
	[SerializeField] private Light spotLight;
	[SerializeField] private float viewDistance;
	[SerializeField] private LayerMask viewMask;
	[SerializeField] private DetectionBar detectionBar;

	private float viewAngle;
	Transform player;
	Color originalSpotLightColor;

	private Patrol patrol;
	private AIDestinationSetter destination;

	private void Awake()
	{
		// Find the patrol script on this object
		patrol = GetComponent<Patrol>();
		if (patrol == null)
		{
			Debug.Log("Patrol not found!");
		}

		// Find the AIDestinationSetter script on this object
		destination = GetComponent<AIDestinationSetter>();
		if (destination == null)
		{
			Debug.Log("Destination not found!");
		}

		// Find the player through the AIDestinationSetter
		player = destination.target;
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
			detectionBar.FillBar();
			patrol.enabled = false;

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
				GoBackToPatrol();
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
