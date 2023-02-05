using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAttackTargetSetter : MonoBehaviour
{
	[SerializeField] DamageOnCollision point;
	int damage;
	public WaterAttackTargetSetter InstigatedBy(IElementHolder instigator)
	{
		point.SetInstigator(instigator);
		return this;
	}
	public WaterAttackTargetSetter OfTarget(Vector3 target)
	{
		
		point.transform.position = target;
		return this;
	}
	public WaterAttackTargetSetter WithDamage(int damage)
	{
		point.onDamageDealt.AddListener(() => Destroy(gameObject));
		point.gameObject.SetActive(false);
		point.Deal(damage).OfElement(Element.Water).OnTrigger();
		StartCoroutine(DamageRoutine());
		return this;
	}

	IEnumerator DamageRoutine()
	{
		yield return new WaitForSeconds(1);
		point.gameObject.SetActive(true);
		yield return new WaitForSeconds(3f);
		Destroy(gameObject);
	}
}
