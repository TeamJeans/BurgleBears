using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmsController : MonoBehaviour
{
	[SerializeField] private GameObject leftArm = null;
	[SerializeField] private GameObject rightArm = null;
	private JointSpring leftArmSpring;
	private JointSpring rightArmSpring;

	public bool LeftArmMovingUp { get; private set; } = false;
	public bool LeftArmMovingDown { get; private set; } = false;
	public bool RightArmMovingUp { get; private set; } = false;
	public bool RightArmMovingDown { get; private set; } = false;
	private float totalLeftArmRotation = 0f;
	private float totalRightArmRotation = 0f;

	private PlayerInput playerInput = null;

	private void Awake()
	{
		if (leftArm == null)
		{
			Debug.Log("Left arm missing from Arm controller script");
		}
		else
		{
			leftArmSpring = leftArm.GetComponent<HingeJoint>().spring;
		}

		if (rightArm == null)
		{
			Debug.Log("Right arm missing from Arm controller script");
		}
		else
		{
			rightArmSpring = rightArm.GetComponent<HingeJoint>().spring;
		}

		playerInput = new PlayerInput();

		playerInput.Gameplay.RaiseLeftArm.performed += ctx => RaiseLeftArm();
		playerInput.Gameplay.RaiseLeftArm.canceled += ctx => LeftArmMovingUp = false;
		playerInput.Gameplay.LowerLeftArm.performed += ctx => LowerLeftArm();
		playerInput.Gameplay.LowerLeftArm.canceled += ctx => LeftArmMovingDown = false;
		playerInput.Gameplay.RaiseRightArm.performed += ctx => RaiseRightArm();
		playerInput.Gameplay.RaiseRightArm.canceled += ctx => RightArmMovingUp = false;
		playerInput.Gameplay.LowerRightArm.performed += ctx => LowerRightArm();
		playerInput.Gameplay.LowerRightArm.canceled += ctx => RightArmMovingDown = false;

	}

	private void Update()
	{
		leftArm.GetComponent<HingeJoint>().spring = leftArmSpring;
		rightArm.GetComponent<HingeJoint>().spring = rightArmSpring;

		if (LeftArmMovingDown || LeftArmMovingUp)
		{
			leftArm.GetComponent<HingeJoint>().useSpring = true;
		}
		else
		{
			leftArm.GetComponent<HingeJoint>().useSpring = false;
			leftArmSpring.targetPosition = 1;
		}

		if (RightArmMovingDown || RightArmMovingUp)
		{
			rightArm.GetComponent<HingeJoint>().useSpring = true;
		}
		else
		{
			rightArm.GetComponent<HingeJoint>().useSpring = false;
			rightArmSpring.targetPosition = 1;
		}
	}

	private void RaiseLeftArm()
	{
		LeftArmMovingUp = true;
		if (leftArmSpring.targetPosition > leftArm.GetComponent<HingeJoint>().limits.min)
		{
			leftArmSpring.targetPosition -= 1;
		}
	}

	private void LowerLeftArm()
	{
		LeftArmMovingDown = true;
		if (leftArmSpring.targetPosition < leftArm.GetComponent<HingeJoint>().limits.max)
		{
			leftArmSpring.targetPosition += 1;
		}
	}

	private void RaiseRightArm()
	{
		RightArmMovingUp = true;
		if (rightArmSpring.targetPosition < rightArm.GetComponent<HingeJoint>().limits.max)
		{
			rightArmSpring.targetPosition += 1;
		}
	}

	private void LowerRightArm()
	{
		RightArmMovingDown = true;
		if (rightArmSpring.targetPosition > rightArm.GetComponent<HingeJoint>().limits.min)
		{
			rightArmSpring.targetPosition -= 1;
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
