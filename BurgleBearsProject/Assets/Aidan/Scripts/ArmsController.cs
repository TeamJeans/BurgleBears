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

	private bool leftArmMovingUp = false;
	private bool leftArmMovingDown = false;
	private bool rightArmMovingUp = false;
	private bool rightArmMovingDown = false;
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
		playerInput.Gameplay.RaiseLeftArm.canceled += ctx => leftArmMovingUp = false;
		playerInput.Gameplay.LowerLeftArm.performed += ctx => LowerLeftArm();
		playerInput.Gameplay.LowerLeftArm.canceled += ctx => leftArmMovingDown = false;
		playerInput.Gameplay.RaiseRightArm.performed += ctx => RaiseRightArm();
		playerInput.Gameplay.RaiseRightArm.canceled += ctx => rightArmMovingUp = false;
		playerInput.Gameplay.LowerRightArm.performed += ctx => LowerRightArm();
		playerInput.Gameplay.LowerRightArm.canceled += ctx => rightArmMovingDown = false;

	}

	private void Update()
	{
		leftArm.GetComponent<HingeJoint>().spring = leftArmSpring;
		rightArm.GetComponent<HingeJoint>().spring = rightArmSpring;

		if (leftArmMovingDown || leftArmMovingUp)
		{
			leftArm.GetComponent<HingeJoint>().useSpring = true;
		}
		else
		{
			leftArm.GetComponent<HingeJoint>().useSpring = false;
			leftArmSpring.targetPosition = 1;
		}

		if (rightArmMovingDown || rightArmMovingUp)
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
		leftArmMovingUp = true;
		if (leftArmSpring.targetPosition > leftArm.GetComponent<HingeJoint>().limits.min)
		{
			leftArmSpring.targetPosition -= 1;
		}
	}

	private void LowerLeftArm()
	{
		leftArmMovingDown = true;
		if (leftArmSpring.targetPosition < leftArm.GetComponent<HingeJoint>().limits.max)
		{
			leftArmSpring.targetPosition += 1;
		}
	}

	private void RaiseRightArm()
	{
		rightArmMovingUp = true;
		if (rightArmSpring.targetPosition < rightArm.GetComponent<HingeJoint>().limits.max)
		{
			rightArmSpring.targetPosition += 1;
		}
	}

	private void LowerRightArm()
	{
		rightArmMovingDown = true;
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
