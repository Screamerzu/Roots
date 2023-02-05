using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NaughtyAttributes;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Enemy))]
public class AIController : MonoBehaviour
{
	[SerializeReference]List<AIAction> possibleActions = new();
	[SerializeReference][ReadOnly] AIAction currentAction;
	[SerializeField][ReadOnly] AbilityCaster abilityCaster = new();
	public Enemy Enemy { get; private set; }
	public NavMeshAgent NavMeshAgent  { get; private set; }

	public AbilityCaster AbilityCaster => abilityCaster;

	void Awake()
	{
		Enemy = GetComponent<Enemy>();
		NavMeshAgent = GetComponent<NavMeshAgent>();
		AbilityCaster.WithAttacks(Attack.ElementAttackMap);

		ChooseNextAction();
	}

	void Update()
	{
		UpdateActions();
		UpdateRotation();
	}

	void UpdateRotation() => transform.rotation = Quaternion.LookRotation((PlayerController.Instance.transform.position - transform.position).normalized);
	void UpdateActions()
	{
		if(currentAction.PerformLoop(this))
		{
			currentAction.Finalize(this);
			ChooseNextAction();
		}
	}

	void ChooseNextAction()
	{
		int maxRandom = 0;
		foreach (var action in possibleActions)
		{
			maxRandom += action.Priority;
		}
		int choice = Random.Range(0, maxRandom);

		int choiceIndetifier = 0;
		foreach (var action in possibleActions)
		{
			choiceIndetifier += action.Priority;
			if(choiceIndetifier >= choice)
			{
				currentAction = action;
				currentAction.Initialize(this);
				return;
			}
		}
	}

	[ContextMenu("Add MoveAction")]
	void AddMoveAction() => possibleActions.Add(new MoveAction());

	[ContextMenu("Add AbilityAction")]
	void AddAbilityAction() => possibleActions.Add(new AbilityAction());
}
