using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NaughtyAttributes;

[RequireComponent(typeof(Motor))]
[RequireComponent(typeof(Enemy))]
public class AIController : MonoBehaviour
{
	[SerializeReference]List<AIAction> possibleActions = new();
	[SerializeReference][ReadOnly] AIAction currentAction;
	[SerializeField][ReadOnly] AbilityCaster abilityCaster = new();
	public Motor Motor  { get; private set; }
	public Enemy Enemy { get; private set; }

	public AbilityCaster AbilityCaster => abilityCaster;

	void Awake()
	{
		Enemy = GetComponent<Enemy>();
		Motor = GetComponent<Motor>();
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

	[ContextMenu("Add AbilityAction")]
	void AddAbilityAction() => possibleActions.Add(new AbilityAction());

	[ContextMenu("Add FollowPlayerAction")]
	void AddFollowPlayerAction() => possibleActions.Add(new FollowPlayerAction());

	[ContextMenu("Add RandomMovementAction")]
	void AddRandomMovementAction() => possibleActions.Add(new RandomMovementAction());
}
