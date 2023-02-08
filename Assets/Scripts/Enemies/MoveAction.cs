using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAction : AIAction
{
	float followTime;
	float startTime;
	public override void Initialize(AIController controller)
	{
		startTime = Time.time;
		followTime = Random.Range(2, 5);
	}
	
	public override bool PerformLoop(AIController controller)
	{
		controller.Motor.MoveTowards(PlayerController.Instance.transform.position);
		
		return IsBeyondFollowTime();
	}
	
	bool IsBeyondFollowTime() => (Time.time - startTime) > followTime;

}
