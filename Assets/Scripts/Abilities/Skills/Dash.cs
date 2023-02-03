using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Skill
{
	const float DASH_LENGTH = 2f;
	public override void StartCasting(Vector3 direction, IElementHolder instigator)
	{
		Player player = instigator as Player;
		player.transform.position += direction.normalized * DASH_LENGTH;
		onFinishedCasting?.Invoke(this);
	}
}
