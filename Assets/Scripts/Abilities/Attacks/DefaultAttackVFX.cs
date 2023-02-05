using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DamageOnCollision))]
public class DefaultAttackVFX : MonoBehaviour
{
	[SerializeField] float speed;
	[SerializeField] Transform rotaryChild;
	DamageOnCollision damageDealer;

	public void Attack()
	{
		damageDealer.onDamageDealt.AddListener(() => Destroy(gameObject));
	}

	void Update()
	{
		rotaryChild.transform.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime);
	}
}
