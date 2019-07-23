using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmsController : MonoBehaviour
{
	[SerializeField] private GameObject leftArm = null;
	[SerializeField] private GameObject rightArm = null;
	private bool leftArmMovingUp = false;
	private bool leftArmMovingDown = false;
	private bool rightArmMovingUp = false;
	private bool rightArmMovingDown = false;
	private float totalLeftArmRotation = 0f;
	private float totalRightArmRotation = 0f;


	private PlayerInput playerInput = null;
	[SerializeField] private JointFollowAnimRot leftArmFollow = null;
	[SerializeField] private JointFollowAnimRot rightArmFollow = null;

	private void Awake()
	{
		playerInput = new PlayerInput();

		playerInput.Gameplay.RaiseLeftArm.performed += ctx => RaiseLeftArm();
		playerInput.Gameplay.RaiseLeftArm.canceled += ctx => leftArmMovingUp = false;
		playerInput.Gameplay.LowerLeftArm.performed += ctx => LowerLeftArm();
		playerInput.Gameplay.LowerLeftArm.canceled += ctx => leftArmMovingDown = false;
		playerInput.Gameplay.RaiseRightArm.performed += ctx => RaiseRightArm();
		playerInput.Gameplay.RaiseRightArm.canceled += ctx => rightArmMovingUp = false;
		playerInput.Gameplay.LowerRightArm.performed += ctx => LowerRightArm();
		playerInput.Gameplay.LowerRightArm.canceled += ctx => rightArmMovingDown = false;

	}

	// Start is called before the first frame update
	void Start()
    {
		leftArmFollow.enabled = false;
		rightArmFollow.enabled = false;

		if (leftArm == null)
		{
			Debug.Log("Left arm missing from Arm controller script");
		}

		if (rightArm == null)
		{
			Debug.Log("Right arm missing from Arm controller script");
		}
	}

	private void Update()
	{
		if (leftArmMovingDown || leftArmMovingUp)
		{
			leftArmFollow.enabled = true;
		}
		else
		{
			leftArmFollow.enabled = false;
			leftArm.transform.rotation = Quaternion.identity;
			leftArm.transform.Rotate(0,0,70);
			totalLeftArmRotation = 70f;
		}

		if (rightArmMovingDown || rightArmMovingUp)
		{
			rightArmFollow.enabled = true;
		}
		else
		{
			rightArmFollow.enabled = false;
			rightArm.transform.rotation = Quaternion.identity;
			rightArm.transform.Rotate(0, 0, -70);
			totalRightArmRotation = -70f;
		}
	}

	private void RaiseLeftArm()
	{
		leftArmMovingUp = true;
		if (totalLeftArmRotation > -90)
		{
			leftArm.transform.Rotate(0, 0, -1);
			totalLeftArmRotation--;
		}
	}

	private void LowerLeftArm()
	{
		leftArmMovingDown = true;
		if (totalLeftArmRotation < 90)
		{
			leftArm.transform.Rotate(0, 0, 1);
			totalLeftArmRotation++;
		}
	}

	private void RaiseRightArm()
	{
		rightArmMovingUp = true;
		if (totalRightArmRotation < 90)
		{
			rightArm.transform.Rotate(0, 0, 1);
			totalRightArmRotation++;
		}
	}

	private void LowerRightArm()
	{
		rightArmMovingDown = true;
		if (totalRightArmRotation > -90)
		{
			rightArm.transform.Rotate(0, 0, -1);
			totalRightArmRotation--;
		}
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
