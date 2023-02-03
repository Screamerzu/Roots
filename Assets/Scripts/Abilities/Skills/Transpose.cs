using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transpose : Skill
{
	public override void StartCasting(Vector3 direction, IElementHolder instigator)
	{
		foreach (var element in Element.All)
		{
			if(instigator.CurrentElementHeld.Dominates(element))
			{
				instigator.Regen(element);
				break;
			}
		}

		onFinishedCasting?.Invoke(this);
	}
}
