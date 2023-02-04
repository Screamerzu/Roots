using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDamage : DamageDealer
{
	[SerializeField] float delay;
	Element element;
	IDamageable target;
	int damageAmount = -1;

	public DelayedDamage Deal(int damageAmount)
	{
		this.damageAmount = damageAmount;
		StartDamageRoutineWhenReady();
		return this;
	}
	public DelayedDamage OfElement(Element element)
	{
		this.element = element;
		StartDamageRoutineWhenReady();
		return this;
	}
	public DelayedDamage To(IDamageable target)
	{
		this.target = target;
		StartDamageRoutineWhenReady();
		return this;
	}

	void StartDamageRoutineWhenReady()
	{
		if(damageAmount is -1)
		{
			return;
		}

		if(target is null)
		{
			return;
		}

		if(element is null)
		{
			return;
		}

		StartCoroutine(DealDelayedDamage());
	}

	IEnumerator DealDelayedDamage()
	{
		yield return new WaitForSeconds(delay);
		DealDamageToTarget(target, damageAmount, element);
	}
}
