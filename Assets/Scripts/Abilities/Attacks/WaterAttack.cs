using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAttack : Attack
{
	const float ATTACK_DISTANCE = 4;

	public WaterAttack()
	{
		DamageDealerPrefabName = "WaterAttackPrefab";
		Damage = 1;
	}
	public override void StartCasting(Vector3 direction, IElementHolder instigator)
	{
		var instigatorTransform = (instigator as MonoBehaviour).transform;
		GameObject damageDealer = GameObject.Instantiate<GameObject>(DamageDealerPrefab, instigatorTransform.position, Quaternion.identity);
		var waterTargetSetter = damageDealer.GetComponent<WaterAttackTargetSetter>();
		waterTargetSetter.InstigatedBy(instigator).OfTarget(instigatorTransform.position + direction * ATTACK_DISTANCE).WithDamage(Damage);
	}
}
