using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAction : AIAction
{
	[SerializeField] float speed;
	[SerializeField] float followDistance;
	public override void Initialize(AIController controller)
	{
		controller.NavMeshAgent.stoppingDistance = followDistance;
		controller.NavMeshAgent.speed = speed;
	}
	
	public override bool PerformLoop(AIController controller)
	{
		controller.NavMeshAgent.SetDestination(PlayerController.Instance.transform.position);
		
		return HasReachedDistantion(controller);
	}
	
	bool HasReachedDistantion(AIController controller) => controller.NavMeshAgent.isStopped;
}
