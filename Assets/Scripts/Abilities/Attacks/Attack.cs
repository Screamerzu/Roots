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

	public Element element { get; protected set; }
}
