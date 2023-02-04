using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : Skill
{
	public Source() => cooldown = 5;
	public override void StartCasting(Vector3 direction, IElementHolder instigator)
	{
		throw new System.NotImplementedException();
	}
}
