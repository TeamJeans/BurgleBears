﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointFollowAnimRot : MonoBehaviour
{
	public bool invert;

	public float torqueForce;
	public float angularDamping;
	public float maxForce;
	public float springForce;
	public float springDamping;

	public Vector3 targetVel;

	public Transform target;
	private GameObject limb;
	private JointDrive drive;
	private SoftJointLimitSpring spring;
	private ConfigurableJoint joint;
	private Quaternion startingRotation;

	void Start()
	{
		invert = false;

		torqueForce = 100f;
		angularDamping = 0.0f;
		maxForce = 100f;

		springForce = 100f;
		springDamping = 0f;

		targetVel = new Vector3(0f, 0f, 0f);

		drive.positionSpring = torqueForce;
		drive.positionDamper = angularDamping;
		drive.maximumForce = maxForce;

		spring.spring = springForce;
		spring.damper = springDamping;

		joint = gameObject.GetComponent<ConfigurableJoint>();

		joint.slerpDrive = drive;

		joint.linearLimitSpring = spring;
		joint.rotationDriveMode = RotationDriveMode.Slerp;
		joint.projectionMode = JointProjectionMode.None;
		joint.targetAngularVelocity = targetVel;
		joint.configuredInWorldSpace = false;
		//joint.swapBodies = true;

		startingRotation = transform.localRotation;
	}

	void LateUpdate()
	{
		if (invert)
			joint.SetTargetRotationLocal(Quaternion.Inverse(target.localRotation), Quaternion.Inverse(startingRotation));
		//joint.targetRotation = Quaternion.Inverse(target.localRotation * startingRotation);
		else
			joint.SetTargetRotationLocal(target.localRotation, startingRotation);
			//joint.targetRotation = target.rotation * startingRotation;
	}

	private void OnEnable()
	{
		joint = gameObject.GetComponent<ConfigurableJoint>();

		drive.positionSpring = torqueForce;
		drive.positionDamper = angularDamping;
		drive.maximumForce = maxForce;

		joint.slerpDrive = drive;

		joint.linearLimitSpring = spring;
		joint.rotationDriveMode = RotationDriveMode.Slerp;
		joint.projectionMode = JointProjectionMode.None;
		joint.targetAngularVelocity = targetVel;
		joint.configuredInWorldSpace = false;
		//joint.swapBodies = true;

		startingRotation = transform.localRotation;
	}

	private void OnDisable()
	{
		joint = gameObject.GetComponent<ConfigurableJoint>();

		drive.positionSpring = 0;
		drive.positionDamper = 0;
		drive.maximumForce = 0;

		joint.slerpDrive = drive;

		joint.linearLimitSpring = spring;
		joint.rotationDriveMode = RotationDriveMode.Slerp;
		joint.projectionMode = JointProjectionMode.None;
		joint.targetAngularVelocity = targetVel;
		joint.configuredInWorldSpace = false;
	}
}
