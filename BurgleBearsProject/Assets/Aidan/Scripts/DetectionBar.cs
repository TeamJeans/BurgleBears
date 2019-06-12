using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionBar : MonoBehaviour
{
	[SerializeField] private float timeForBarToDeplete = 5f;
	private float timeForBarToFill = 1f;
	public float TimeForBarToFill { get { return timeForBarToFill; } set { timeForBarToFill = value; } }
	private float elapsedFillTime = 0;
	private float elapsedDepleteTime = 0;
	[SerializeField] private Vector2 barEndPos = Vector2.zero;
	private Vector2 barStartPos = Vector2.zero;
	public bool Full { get; private set; }
	public bool Depleted { get; private set; }

	// Start is called before the first frame update
	void Start()
	{
		barStartPos = transform.localPosition;
	}

	public void FillBar()
	{
		Depleted = false;		// It shouldn't be depleted as we are starting to fill the bar
		elapsedDepleteTime = 0;

		float percentageLeftToFill = Vector2.Distance(transform.localPosition, barEndPos) / Vector2.Distance(barStartPos, barEndPos);
		transform.localPosition = Vector2.Lerp(transform.localPosition, barEndPos, 1 / (timeForBarToFill*percentageLeftToFill) * Time.deltaTime);
		if (elapsedFillTime >= timeForBarToFill)
		{
			Full = true;
			elapsedFillTime = 0;
		}
		else
		{
			elapsedFillTime += Time.deltaTime;
		}
	}

	public void DepleteBar()
	{
		Full = false;       // It shouldn't be full as we are starting to deplete the bar
		elapsedFillTime = 0;

		float percentageLeftToDeplete = Vector2.Distance(transform.localPosition, barStartPos) / Vector2.Distance(barStartPos, barEndPos);
		transform.localPosition = Vector2.Lerp(transform.localPosition, barStartPos, 1 / (timeForBarToDeplete * percentageLeftToDeplete) * Time.deltaTime);
		if (elapsedDepleteTime >= timeForBarToDeplete)
		{
			Depleted = true;
			elapsedDepleteTime = 0;
		}
		else
		{
			elapsedDepleteTime += Time.deltaTime;
		}
	}
}
