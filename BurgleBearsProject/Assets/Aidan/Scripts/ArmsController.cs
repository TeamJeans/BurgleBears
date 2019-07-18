using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmsController : MonoBehaviour
{
	[SerializeField] private GameObject leftArm = null;
	[SerializeField] private GameObject rightArm = null;

	PlayerInput playerInput = null;

	private void Awake()
	{
		playerInput = new PlayerInput();

		playerInput.Gameplay.RaiseLeftArm.performed += ctx => RaiseLeftArm();
		playerInput.Gameplay.LowerLeftArm.performed += ctx => LowerLeftArm();
		playerInput.Gameplay.RaiseRightArm.performed += ctx => RaiseRightArm();
		playerInput.Gameplay.LowerRightArm.performed += ctx => LowerRightArm();

	}

	// Start is called before the first frame update
	void Start()
    {
		if (leftArm == null)
		{
			Debug.Log("Left arm missing from Arm controller script");
		}

		if (rightArm == null)
		{
			Debug.Log("Right arm missing from Arm controller script");
		}
	}

	private void RaiseLeftArm()
	{
		float rot = 0;
		rot--;
		leftArm.transform.Rotate(0, 0, rot);
		rot = 0f;
	}

	private void LowerLeftArm()
	{
		float rot = 0;
		rot++;
		leftArm.transform.Rotate(0, 0, rot);
		rot = 0f;
	}

	private void RaiseRightArm()
	{
		float rot = 0;
		rot++;
		rightArm.transform.Rotate(0, 0, rot);
		rot = 0f;
	}

	private void LowerRightArm()
	{
		float rot = 0;
		rot--;
		rightArm.transform.Rotate(0, 0, rot);
		rot = 0f;
	}

	private void OnEnable()
	{
		playerInput.Gameplay.Enable();
	}

	private void OnDisable()
	{
		playerInput.Gameplay.Disable();
	}
}
