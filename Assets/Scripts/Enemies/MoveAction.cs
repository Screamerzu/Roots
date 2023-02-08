using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NaughtyAttributes;

public abstract class MoveAction : AIAction
{
	[SerializeField] protected float maxFollowTime = Mathf.Infinity;
	[SerializeField] float tolerance = 1;
	protected Vector3 target;
	float startTime;
	public override void Initialize(AIController controller)
	{
		startTime = Time.time;
	}
	
	public override bool PerformLoop(AIController controller)
	{
		controller.Motor.MoveTowards(target);
		Debug.Log($"Within Tolerance: {IsWithinTolerance(controller.transform.position)}");
		return IsBeyondFollowTime() || IsWithinTolerance(controller.transform.position);
	}
	
	bool IsBeyondFollowTime() => (Time.time - startTime) > maxFollowTime;
	bool IsWithinTolerance(Vector3 currentPosition) => Vector3.Distance(currentPosition, target) <= tolerance;

}
