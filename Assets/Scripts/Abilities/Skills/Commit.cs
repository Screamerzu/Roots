using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commit : Skill
{
	const float DURATION = 5;
	
	public Commit() => cooldown = 10;
	Player player;
	Element lockedElement;

	public override void StartCasting(Vector3 direction, IElementHolder instigator)
	{
		player = instigator as Player;
		lockedElement = player.CurrentElementHeld;
		player.OnElementHeldChanged.AddListener(ChangeElement);
		player.StartCoroutine(LockElement());
		onFinishedCasting?.Invoke(instigator, this);
	}

	void ChangeElement(Element element) => (player as IElementHolder).Regen(lockedElement);

	IEnumerator LockElement()
	{
		yield return new WaitForSeconds(DURATION);
		player.OnElementHeldChanged.RemoveListener(ChangeElement);
	}
}
