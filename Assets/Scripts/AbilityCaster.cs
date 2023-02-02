using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using NaughtyAttributes;

[System.Serializable]
public class AbilityCaster
{
	Dictionary<Element, Attack> attacks;
	Dictionary<Skill, float> skillCooldowns;
	public Ability.OnFinishedCasting onFinishedCasting;
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

	public bool UseSkill(IElementHolder instigator, Skill skill, Vector2 direction)
	{
		if(isCasting)
		{
			return false;
		}

		if(skillCooldowns[skill] > 0)
		{
			return false;
		}
		
		onFinishedCasting = skill.StartCasting(direction, instigator);
		return true;
	}

	public bool Attack(IElementHolder instigator, Element element, Vector2 direction)
	{
		if(isCasting)
		{
			return false;
		}

		onFinishedCasting = attacks[element].StartCasting(direction, instigator);
		return true;
	}

	void OnCastDone()
	{
		isCasting = false;
	}
}
