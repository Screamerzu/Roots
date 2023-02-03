using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

[System.Serializable]
public class AbilityCaster
{
	public static UnityAction<Ability> onStartCasting;
	public static UnityAction<Ability> onFinishedCasting;
	Dictionary<Element, Attack> attacks;
	Dictionary<Skill, float> skillCooldowns;
	[SerializeField][ReadOnly] bool isCasting;

	public AbilityCaster()
	{
		attacks = new();
		skillCooldowns = new();
		onFinishedCasting += OnCastDone;
	}

	public AbilityCaster WithAttacks(Dictionary<Element, Attack> attacks)
	{
		this.attacks = attacks;
		return this;
	}

	public AbilityCaster WithSkills(Dictionary<Skill, float> skills)
	{
		this.skillCooldowns = skills;
		return this;
	}

	public void UpdateCooldowns()
	{
		foreach (var key in skillCooldowns.Keys.ToArray())
		{
			skillCooldowns[key] -= Time.deltaTime;
		}
	}

	public bool UseSkill(IElementHolder instigator, Skill skill, Vector3 direction)
	{
		if(isCasting)
		{
			return false;
		}

		if(skillCooldowns[skill] > 0)
		{
			return false;
		}
		
		skill.onFinishedCasting.AddListener(onFinishedCasting);
		skill.StartCasting(direction, instigator);
		onStartCasting?.Invoke(skill);
		return true;
	}

	public bool Attack(IElementHolder instigator, Element element, Vector3 direction)
	{
		if(isCasting)
		{
			return false;
		}

		attacks[element].onFinishedCasting.AddListener(onFinishedCasting);
		attacks[element].StartCasting(direction, instigator);
		onStartCasting?.Invoke(attacks[element]);
		return true;
	}

	void OnCastDone(Ability ability)
	{
		foreach (var skill in skillCooldowns)
		{
			if(skill.Key == ability)
			{
				skill.Key.onFinishedCasting.RemoveListener(onFinishedCasting);
			}
		}

		foreach (var attack in attacks)
		{
			if(attack.Value == ability)
			{
				attack.Value.onFinishedCasting.RemoveListener(onFinishedCasting);
			}
		}

		isCasting = false;
	}
}
