using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunnyJarPickup : MonoBehaviour
{
	[SerializeField] private GameObject pickupEffect;
	[SerializeField] private int value = 1;
	private GameManager gM;

	// Use this for initialization
	void Start()
	{
		gM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			gM.AddHunnyJar(value);

			//Instantiate(pickupEffect, transform.position, transform.rotation);

			Destroy(gameObject);
		}
	}
}
