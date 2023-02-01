using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IDamageable
{
	[SerializeField] int maxHealth = 3;
	int health;

	void Awake() => health = maxHealth;

	public void Damage(int value, Element element)
	{
		health -= value;
	}
}
