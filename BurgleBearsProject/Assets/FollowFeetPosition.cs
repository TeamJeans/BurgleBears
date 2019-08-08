using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFeetPosition : MonoBehaviour
{
	[SerializeField] private Vector3 offset = Vector3.zero;
	[SerializeField] private Transform feet = null;

    // Update is called once per frame
    void Update()
    {
		transform.position = feet.position + offset;
	}
}
