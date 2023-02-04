using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAttack : Attack
{
	const float ATTACK_DISTANCE = 4;

	public WaterAttack() => DamageDealerPrefabName = "WaterAttackPrefab";
	public override void StartCasting(Vector3 direction, IElementHolder instigator)
	{
		throw new System.NotImplementedException();
		var instigatorTransform = (instigator as MonoBehaviour).transform;
		DamageDealer damageDealer = GameObject.Instantiate<DamageDealer>(DamageDealerPrefab, instigatorTransform.position + instigatorTransform.forward * ATTACK_DISTANCE, Quaternion.identity);
	}
}
