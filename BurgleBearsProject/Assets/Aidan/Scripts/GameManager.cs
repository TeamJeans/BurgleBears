using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Text hunnyJarsText = null;
	private int noOfHunnyJarsCollected = 0;

	private void Update()
	{
		hunnyJarsText.text = "HunnyJars: " + noOfHunnyJarsCollected;	// Update the ui text for hunny jars
	}

	public void AddHunnyJar(int val)
	{
		noOfHunnyJarsCollected += val;	// Increment the number of hunny jars
	}
}
