using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armControl : MonoBehaviour
{
    private float rotx = 0;
	[SerializeField] private HingeJointTarget hjt = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            rotx++;
        }
        if (Input.GetKey(KeyCode.K))
        {
            rotx--;
        }

		hjt.TargetRotation += rotx;
		transform.Rotate(rotx,0,0);
        rotx = 0;
    }

}
