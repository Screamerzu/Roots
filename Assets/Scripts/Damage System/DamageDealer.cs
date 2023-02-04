using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class DamageDealer : MonoBehaviour
{
	public static UnityEvent<int> OnDamageDealt;
	public static UnityEvent<int> OnPerfectDamageDealt;

	[SerializeField][ReadOnly] IElementHolder instigator;

	public void SetInstigator(IElementHolder instigator) => this.instigator = instigator;

	public void DealDamageToTarget(IDamageable target, int damageAmount, Element element)
	{
		if(!IsTargetValid(target))
		{
			Debug.LogError("Target Invalid!");
			return;
		}

		target.Damage(damageAmount, element);
		OnDamageDealt?.Invoke(damageAmount);
	}

	public bool IsTargetValid(IDamageable target)
	{
		if(instigator is null)
		{
			Debug.LogError("Instigator has not been set, cannot validate target!");
		}

		return target.GetType() != instigator.GetType();
	}
}
