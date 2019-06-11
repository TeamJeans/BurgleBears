using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampDetectionEye : MonoBehaviour
{
	[SerializeField] GameObject detectionEye;

    // Update is called once per frame
    void Update()
    {
		Vector3 eyePos = Camera.main.WorldToScreenPoint(this.transform.position);
		detectionEye.transform.position = eyePos;
    }
}
