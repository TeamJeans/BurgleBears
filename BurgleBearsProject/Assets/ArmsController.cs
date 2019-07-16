using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsController : MonoBehaviour
{
	[SerializeField] private GameObject leftArm = null;
	[SerializeField] private GameObject rightArm = null;

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

    // Update is called once per frame
    void Update()
    {
		float rotx = 0;
		if (Input.GetKey(KeyCode.J))
		{
			rotx++;
		}
		if (Input.GetKey(KeyCode.K))
		{
			rotx--;
		}

		leftArm.transform.Rotate(0, rotx, 0);
		rotx = 0;
	}
}
