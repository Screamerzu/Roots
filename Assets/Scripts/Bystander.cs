
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Bystander : MonoBehaviour
{
	const float ENERGY_DEPLETION_SPEED = 2;
	[SerializeField] AnimationCurve moveCurve;
	[SerializeField] float defaultEnergy = 3;
	[SerializeField][ReadOnly] float currentEnergy;
	float initialYValue;
	float randomSeed;
	Coroutine energyDepeletionRoutine;

	void Awake()
	{
		initialYValue = transform.position.y;
		currentEnergy = defaultEnergy;
		randomSeed = Random.Range(0, 1000);
	}
	void Update()
	{
		transform.position = new Vector3(transform.position.x, initialYValue + currentEnergy * moveCurve.Evaluate(randomSeed + Time.time), transform.position.z);
	}

	public void BoostEnergy(float multiplier)
	{
		currentEnergy = defaultEnergy * multiplier;
		if(energyDepeletionRoutine is not null)
		{
			return;
		}
		
		energyDepeletionRoutine = StartCoroutine(EnergyDepletionCoroutine());
	}

	IEnumerator EnergyDepletionCoroutine()
	{
		while(currentEnergy > defaultEnergy)
		{
			currentEnergy = Mathf.Clamp(currentEnergy - Time.deltaTime * ENERGY_DEPLETION_SPEED, defaultEnergy, Mathf.Infinity);
			yield return null;
		}
	}
}
