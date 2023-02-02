using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commit : Skill
{
	const float DURATION = 5;
	
	public Commit() => cooldown = 10;
	Player player;
	Element lockedElement;

	public override OnFinishedCasting StartCasting(Vector3 direction, IElementHolder instigator)
	{
		player = instigator as Player;
		lockedElement = player.CurrentElementHeld;
		player.GetComponent<PlayerController>().AbilityCaster.onFinishedCasting += ChangeElement;
		player.StartCoroutine(LockElement());
		return onFinishedCasting;
	}

	void ChangeElement() => (player as IElementHolder).Regen(lockedElement);

	IEnumerator LockElement()
	{
		yield return new WaitForSeconds(DURATION);
		player.GetComponent<PlayerController>().AbilityCaster.onFinishedCasting -= ChangeElement;
	}
}
