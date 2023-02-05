using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthAttack : Attack
{
	public EarthAttack()
	{
		Damage = 1;
		DamageDealerPrefabName = "EarthAttackPrefab";
	}
	public override void StartCasting(Vector3 direction, IElementHolder instigator)
	{
		Transform instigatorTransform = (instigator as MonoBehaviour).transform;
		var punchPrefab = GameObject.Instantiate(DamageDealerPrefab, instigatorTransform.position, Quaternion.LookRotation(instigatorTransform.forward));
		var damageDealer = punchPrefab.GetComponent<DamageOnCollision>().Deal(Damage).OfElement(Element.Earth).OnTrigger().ThenSelfDestructIn(3);
	}
}
