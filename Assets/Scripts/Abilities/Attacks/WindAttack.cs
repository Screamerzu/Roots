using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAttack : Attack
{

	public WindAttack()
	{
		DamageDealerPrefabName = "WindAttackPrefab";
		Damage = 1;
	}

	public override void StartCasting(Vector3 direction, IElementHolder instigator)
	{
		Transform instigatorTransform = (instigator as MonoBehaviour).transform;
		DamageOnCollision damageDealer = GameObject.Instantiate(DamageDealerPrefab, instigatorTransform.position, Quaternion.LookRotation(instigatorTransform.forward)).GetComponent<DamageOnCollision>();

		damageDealer.SetInstigator(instigator);
		damageDealer.Deal(Damage).OfElement(Element.Wind).OnTrigger().ThenSelfDestructIn(3);

		onFinishedCasting?.Invoke(instigator, this);
	}
}
