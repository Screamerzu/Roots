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
		GameObject projectile = GameObject.Instantiate(DamageDealerPrefab, (instigator as MonoBehaviour).transform.position, Quaternion.LookRotation(direction));
		var damageDealer = projectile.GetComponent<DamageOnCollision>();
		damageDealer.SetInstigator(instigator);
		damageDealer.Deal(Damage).OfElement(Element.Fire).OnCollision().ThenSelfDestructImmediately();
		onFinishedCasting?.Invoke(instigator, this);
	}
}
