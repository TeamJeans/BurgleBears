using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrab : MonoBehaviour
{
	[SerializeField] private LayerMask grabableObjectsMask;
	[SerializeField] private ArmsController armsController = null;
	private bool attached = false;
	private GameObject connectedGameObject = null;

	enum WhichHand
	{
		LEFT,
		RIGHT
	}

	[SerializeField] private WhichHand hand;

	private void OnTriggerEnter(Collider other)
	{
		if (grabableObjectsMask == (grabableObjectsMask | (1 << other.gameObject.layer)))
		{
			if (!attached)
			{
				other.gameObject.transform.SetParent(transform);

				other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
				connectedGameObject = other.gameObject;
				attached = true;
			}
		}
	}

	private void Update()
	{
		if (attached)
		{
			switch (hand)	
			{
				case WhichHand.LEFT:
					if (!armsController.LeftArmMovingUp && !armsController.LeftArmMovingDown)
					{
						attached = false;
						connectedGameObject.transform.SetParent(null);
						connectedGameObject.GetComponent<Rigidbody>().isKinematic = false;
						connectedGameObject = null;
					}
					break;
				case WhichHand.RIGHT:
					if (!armsController.RightArmMovingUp && !armsController.RightArmMovingDown)
					{
						attached = false;
						connectedGameObject.transform.SetParent(null);
						connectedGameObject.GetComponent<Rigidbody>().isKinematic = false;
						connectedGameObject = null;
					}
					break;
				default:
					break;
			}
		}
	}
}
