using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUpright : MonoBehaviour
{
	[SerializeField] private bool keepUpRight = true;
	[SerializeField] private float upRightForce = 10f;
	[SerializeField] private float upRightOffset = 1.45f;
	[SerializeField] private float additionalUpwardForce = 10f;
	[SerializeField] private float dampenAngularForce = 0;

	new protected Rigidbody rigidbody = null;


	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
		if (rigidbody == null)
		{
			Debug.Log("Rigidbody not found in CharacterUprightScript!: " + gameObject);
		}
		else
		{
			rigidbody.maxAngularVelocity = 40; // CANNOT APPLY HIGH ANGULAR FORCES UNLESS THE MAXANGULAR VELOCITY IS INCREASED
		}
	}

	private void FixedUpdate()
	{
		if (keepUpRight)
		{
			// USE TWO FORCES PULLING UP AND DOWN AT THE TOP AND BOTTOM OF THE OBJECT RESPECTIVELY TO PULL IT UPRIGHT
			// THIS TECHNIQUE CAN BE USED FOR PULLING AN OBJECT TO FACE ANY VECTOR
			rigidbody.AddForceAtPosition(new Vector3(0, (upRightForce + additionalUpwardForce), 0), transform.position + transform.TransformPoint(new Vector3(0, upRightOffset, 0)), ForceMode.Force);
			rigidbody.AddForceAtPosition(new Vector3(0, -upRightForce, 0), transform.position + transform.TransformPoint(new Vector3(0, -upRightOffset, 0)), ForceMode.Force);
		}

		if (dampenAngularForce > 0)
		{
			rigidbody.angularVelocity *= (1 - Time.deltaTime * dampenAngularForce);
		}
	}
}
