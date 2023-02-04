using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class BystanderManager : MonoBehaviour
{
	public static BystanderManager Instance;
	const float DEFAULT_BOOST_AMOUNT = 3f;
	[SerializeField] int numberOfBystanders = 100;
	[SerializeField] float minRadius = 0;
	[SerializeField] float maxRadius = 100;
	[SerializeField] Bystander bystanderPrefab;
	[SerializeField] List<Vector3> bystandersPreCoordinates = new();
	[SerializeField] List<Bystander> bystanders;

	void OnValidate()
	{
		numberOfBystanders = Mathf.Clamp(numberOfBystanders, 0, int.MaxValue);
		MatchBystanderCount();
	}

	void Awake()
	{
		Instance = this;
		CreateBystandersFromPreList();
	}

	void CreateNewBystander()
	{
		Vector3 bystanderPosition = transform.position;
		while(Vector3.Distance(bystanderPosition, transform.position) <= minRadius)
		{
			bystanderPosition = transform.position + Random.insideUnitSphere * maxRadius;
			bystanderPosition.y = transform.position.y;
		}
		
		bystandersPreCoordinates.Add(bystanderPosition);
	}

	void RemoveBystander()
	{
		bystandersPreCoordinates.RemoveAt(bystandersPreCoordinates.Count - 1);
	}

	void MatchBystanderCount()
	{
		while(numberOfBystanders != bystandersPreCoordinates.Count)
		{
			if(numberOfBystanders > bystandersPreCoordinates.Count)
			{
				CreateNewBystander();
			}
			else
			{
				RemoveBystander();
			}
		}
	}

	void CreateBystandersFromPreList()
	{
		foreach (var newBystanderCoordinate in bystandersPreCoordinates)
		{
			Bystander newBystander = Instantiate(bystanderPrefab, newBystanderCoordinate, Quaternion.LookRotation((transform.position - newBystanderCoordinate).normalized));
			newBystander.transform.SetParent(transform);
			bystanders.Add(newBystander);
		}
	}

	public void BoostEnergy(float boostAmount = DEFAULT_BOOST_AMOUNT)
	{
		foreach (var bystander in bystanders)
		{
			bystander.BoostEnergy(DEFAULT_BOOST_AMOUNT);
		}
	}

	public void Randomize()
	{
		bystandersPreCoordinates.Clear();
		MatchBystanderCount();
	}
}
