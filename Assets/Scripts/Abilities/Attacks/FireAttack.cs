using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : Attack
{
	const string PROJECTILE_PREFAB_NAME = "FireAttackProjectile";

	public FireAttack()
	{
		DamageDealerPrefabName = PROJECTILE_PREFAB_NAME;
		Damage = 1;
	}

	public override void StartCasting(Vector3 direction, IElementHolder instigator)
	{
		throw new System.NotImplementedException();

		DamageDealer projectile = GameObject.Instantiate(DamageDealerPrefab, (instigator as MonoBehaviour).transform);
		(projectile as DamageOnCollision).Deal(Damage).OfElement(Element.Fire).OnTrigger().ThenSelfDestruct();
	}
}
