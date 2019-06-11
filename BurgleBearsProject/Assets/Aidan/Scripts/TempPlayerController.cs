using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerController : MonoBehaviour
{
	[SerializeField] private float movementSpeed = 10f;
	private CharacterController characterController;

    // Start is called before the first frame update
    void Awake()
    {
		characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
		// Caluculate the movement velocity as a 3D vector
		float moveX = Input.GetAxisRaw("Horizontal");
		float moveZ = Input.GetAxisRaw("Vertical");

		Vector3 moveHorizontal = transform.right * moveX;
		Vector3 moveVertical = transform.forward * moveZ;

		// Final movement vector
		Vector3 velocity = (moveHorizontal + moveVertical).normalized * movementSpeed;

		// Apply movement
		characterController.Move(velocity * Time.deltaTime);
	}
}
