using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

	[SerializeField] private Transform target = null;
	[SerializeField] private float sensitivityX = 1f;
	[SerializeField] private float sensitivityY = 1f;
	[SerializeField] private float maxViewAngle = 50f;
	[SerializeField] private float minViewAngle = 0f;
	[SerializeField] private bool invertY = false;
	[SerializeField] private bool stationaryCamera = false;
	[SerializeField] private Vector3 offset = Vector3.zero;
	private Camera cam = null;
	private float currentX = 0f;
	private float currentY = 0f;

	void Start()
	{
		cam = GetComponent<Camera>();
	}

	void Update()
	{
		currentX += Input.GetAxisRaw("RightJoystickHorizontal") * sensitivityX;
		if (invertY)
			currentY += Input.GetAxisRaw("RightJoystickVertical") * sensitivityY;
		else
			currentY -= Input.GetAxisRaw("RightJoystickVertical") * sensitivityY;

		currentY = Mathf.Clamp(currentY, minViewAngle, maxViewAngle);
	}

	void LateUpdate()
	{
		Quaternion rotation = Quaternion.Euler(currentY, currentX, 0f);
		if (!stationaryCamera)
			transform.position = target.position + rotation * offset;
		else
			transform.position = target.position + offset;

		if (transform.position.y < target.position.y - .5f)
			transform.position = new Vector3(transform.position.x, target.position.y - .5f, transform.position.z);

		transform.LookAt(target.position);
	}
}
