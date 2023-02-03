using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class AbilityAction : AIAction
{
	bool isPerformed = false;
	public override void Initialize(AIController controller)
	{
		AbilityCaster.onFinishedCasting += OnCastDone;
		controller.AbilityCaster.Attack(controller.Enemy, controller.Enemy.CurrentElementHeld, controller.transform.forward);
	}
	public override bool PerformLoop(AIController controller) => isPerformed;

	void OnCastDone(IElementHolder instigator, Ability ability)
	{
		AbilityCaster.onFinishedCasting -= OnCastDone;
		isPerformed = true;
	}

}
