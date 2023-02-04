using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AbilityCaster))]
public class AbilityAnimationHandler : MonoBehaviour
{
	[SerializeField] Animator animator;
	AbilityCaster abilityCaster;
	IElementHolder elementHolder;

	void Awake()
	{
		elementHolder = GetComponent<IElementHolder>();
		abilityCaster = GetComponent<AbilityCaster>();
	}

	void OnEnable() => AbilityCaster.onStartCasting += OnStartCasting;
	void OnDisable() => AbilityCaster.onStartCasting -= OnStartCasting;

	void OnStartCasting(IElementHolder elementHolder, Ability ability)
	{
		if(elementHolder != this.elementHolder)
		{
			return;
		}

		animator.Play(ability.AnimationStateName);
	}


	
}
