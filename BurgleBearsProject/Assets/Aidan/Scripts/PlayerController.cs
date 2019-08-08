using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//[SerializeField] private float jumpForce = 0f;
	[SerializeField] private float moveSpeed = 0f;
	[SerializeField] private float gravityScale = 0f;
	[SerializeField] private float rotateSpeed = 0f;
	[SerializeField] private Transform pivot = null;
	[SerializeField] private GameObject playerModel = null;
	[SerializeField] private Animator legAnimator = null;
	private CharacterController controller;
	private Vector3 moveDir = Vector3.zero;


	// Use this for initialization
	void Awake ()
	{
		controller = GetComponent<CharacterController>();
		if (controller == null)
		{
			Debug.Log("controller not found in player controller script!");
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
		controller.Move(moveDir * Time.deltaTime);

		// Move the player in different directions depending on the camera's look direction
		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
		{
			transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
			Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDir.x, 0f, moveDir.z));
			playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
		}

		if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
		{
			legAnimator.SetFloat("Speed", .5f);
		}
		else
		{
			legAnimator.SetFloat("Speed", 0f);
		}
	}
}
