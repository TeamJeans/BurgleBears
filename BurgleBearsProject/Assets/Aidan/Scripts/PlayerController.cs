using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//[SerializeField] private float jumpForce = 0f;
	[SerializeField] private float moveSpeed = 0f;
	[SerializeField] private float gravityScale = 0f;
	[SerializeField] private float rotateSpeed = 0f;
	[SerializeField] private Transform pivot = null;
	private Rigidbody rb;
	private Vector3 moveDir = Vector3.zero;

	// Use this for initialization
	void Awake ()
	{
		rb = GetComponent<Rigidbody>();
		if (rb == null)
		{
			Debug.Log("RigidBody not found in player controller script!");
		}
	}

	// Update is called once per frame
	void Update ()
	{
		// Calculate the direction the player is moving in
		float yStore = moveDir.y;
		moveDir = (transform.forward * Input.GetAxis("Vertical") * moveSpeed) + (transform.right * Input.GetAxis("Horizontal") * moveSpeed);
		moveDir = moveDir.normalized * moveSpeed;
		moveDir.y = yStore;

		// Apply gravity
		moveDir.y += (Physics.gravity.y * gravityScale * Time.deltaTime);

		// Move the player
		rb.AddForce(moveDir);

		// Move the player in different directions depending on the camera's look direction
		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
		{
			transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y,0f);
			Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDir.x, 0f, moveDir.z));
			//rb.MoveRotation(newRotation);
			//Quaternion.Slerp(transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
		}
	}
}
