using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAction : AIAction
{
	[SerializeField] float speed;
	[SerializeField] float followDistance;
	float followTime;
	float startTime;
	public override void Initialize(AIController controller)
	{
		startTime = Time.time;
		followTime = Random.Range(2, 5);
		controller.NavMeshAgent.stoppingDistance = followDistance;
		controller.NavMeshAgent.speed = speed;
	}
	
	public override bool PerformLoop(AIController controller)
	{
		controller.NavMeshAgent.SetDestination(PlayerController.Instance.transform.position);
		
		return IsBeyondFollowTime();
	}
	
	bool IsBeyondFollowTime() => (Time.time - startTime) > followTime;

}
