using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : Ability
{
	public static Attack DefaultAttack { get; private set; } = new DefaultAttack();
	public static Attack FireAttack { get; private set; } = new FireAttack();
	public static Attack WaterAttack { get; private set; } = new WaterAttack();
	public static Attack WindAttack { get; private set; } = new WindAttack();
	public static Attack EarthAttack { get; private set; } = new EarthAttack();
	public static readonly Dictionary<Element, Attack> ElementAttackMap = new()
	{ 
		{ Element.Default, Attack.DefaultAttack },
		{ Element.Earth, Attack.EarthAttack },
		{ Element.Fire, Attack.FireAttack },
		{ Element.Water, Attack.WaterAttack },
		{ Element.Wind, Attack.WindAttack },
	};
	public Element element { get; protected set; }
	
	protected string DamageDealerPrefabName{ get; set; }
	protected GameObject DamageDealerPrefab => Resources.Load<GameObject>(DamageDealerPrefabName);
	protected int Damage{ get; set; }

}
