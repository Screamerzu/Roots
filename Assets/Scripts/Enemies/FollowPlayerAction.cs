using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerAction : MoveAction
{
	public override void Initialize(AIController controller)
	{
		base.Initialize(controller);
		target = PlayerController.Instance.transform.position;
	}
}
