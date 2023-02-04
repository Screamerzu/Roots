using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

[System.Serializable]
public class AbilityCaster
{
	public static UnityAction<IElementHolder, Ability> onStartCasting;
	public static UnityAction<IElementHolder, Ability> onFinishedCasting;
	public Dictionary<Element, Attack> Attacks{ get; private set; }
	public Dictionary<Skill, float> SkillCooldowns{ get; private set; }
	[SerializeField][ReadOnly] bool isCasting;

	public AbilityCaster()
	{
		Attacks = new();
		SkillCooldowns = new();
		onFinishedCasting += OnCastDone;
	}

	public AbilityCaster WithAttacks(Dictionary<Element, Attack> attacks)
	{
		this.Attacks = attacks;
		return this;
	}

	public AbilityCaster WithSkills(Dictionary<Skill, float> skills)
	{
		this.SkillCooldowns = skills;
		return this;
	}

	public void UpdateCooldowns()
	{
		foreach (var key in SkillCooldowns.Keys.ToArray())
		{
			SkillCooldowns[key] -= Time.deltaTime;
		}
	}

	public bool UseSkill(IElementHolder instigator, Skill skill, Vector3 direction)
	{
		if(isCasting)
		{
			return false;
		}

		if(SkillCooldowns[skill] > 0)
		{
			return false;
		}
		
		SkillCooldowns[skill] = skill.cooldown;
		skill.onFinishedCasting.AddListener(onFinishedCasting);
		skill.StartCasting(direction, instigator);
		onStartCasting?.Invoke(instigator, skill);
		return true;
	}

	public bool Attack(IElementHolder instigator, Element element, Vector3 direction)
	{
		if(isCasting)
		{
			return false;
		}

		Attacks[element].onFinishedCasting.AddListener(onFinishedCasting);
		Attacks[element].StartCasting(direction, instigator);
		onStartCasting?.Invoke(instigator, Attacks[element]);
		return true;
	}

	void OnCastDone(IElementHolder elementHolder, Ability ability)
	{
		foreach (var skill in SkillCooldowns)
		{
			if(skill.Key == ability)
			{
				skill.Key.onFinishedCasting.RemoveListener(onFinishedCasting);
			}
		}

		foreach (var attack in Attacks)
		{
			if(attack.Value == ability)
			{
				attack.Value.onFinishedCasting.RemoveListener(onFinishedCasting);
			}
		}

		isCasting = false;
	}
}
