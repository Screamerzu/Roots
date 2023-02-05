using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : Skill
{
	const int Damage = 1;
	const string PREFAB_NAME = "SourceAttackPrefab";
	public Source() => cooldown = 5;
	public override void StartCasting(Vector3 direction, IElementHolder instigator)
	{
		DamageOnCollision damageDealerPrefab = Resources.Load<DamageOnCollision>(PREFAB_NAME);

		Transform instigatorTransform = (instigator as MonoBehaviour).transform;
		DamageOnCollision damageDealer = GameObject.Instantiate(damageDealerPrefab, instigatorTransform.position, Quaternion.LookRotation(instigatorTransform.forward)).GetComponent<DamageOnCollision>();

		damageDealer.SetInstigator(instigator);
		damageDealer.Deal(Damage).OfElement(Element.SuperiorToAll).OnTrigger().ThenSelfDestructIn(3);

		onFinishedCasting?.Invoke(instigator, this);
	}
}
