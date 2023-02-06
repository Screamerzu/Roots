using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using NaughtyAttributes;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(Motor))]
[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
	public static PlayerController Instance;
	static readonly Dictionary<Skill, float> PlayerSkills = new()
	{ 
		{ Skill.Source, 0 },
		{ Skill.Transpose, 0 },
		{ Skill.Dash, 0 },
		{ Skill.Commit, 0 },
	};

	[SerializeField][ReadOnly] AbilityCaster abilityCaster;
	public AbilityCaster AbilityCaster => abilityCaster;
	public Player Player { get; private set; }
	public InputManager InputManager { get; private set; }
	public Motor Motor { get; private set; }

	void Awake()
	{
		Instance = this;
		Player = GetComponent<Player>();
		InputManager = GetComponent<InputManager>();
		Motor = GetComponent<Motor>();
		AbilityCaster.WithSkills(PlayerSkills).WithAttacks(Attack.ElementAttackMap);
	}

	void OnEnable()
	{
		InputManager.onShoot.AddListener(AttackCurrentElement);
		InputManager.onSkillUsed.AddListener(UseSkill);
	}

	void OnDisable()
	{
		InputManager.onShoot.RemoveListener(AttackCurrentElement);
		InputManager.onSkillUsed.RemoveListener(UseSkill);
	}

	void Update()
	{
		UpdateMovement(InputManager.MoveValue);
		AbilityCaster.UpdateCooldowns();
	}

	void FixedUpdate() => UpdateRotation(InputManager.LookDirection);

	void AttackCurrentElement()
	{
		if(AbilityCaster.Attack(Player, Player.CurrentElementHeld, InputManager.LookDirection))
		{
			(Player as IElementHolder).Consume();
		}
	}

	void UpdateMovement(Vector3 direction) => Motor.MoveRelativeToCamera(direction);

	void UpdateRotation(Vector3 forward) => Motor.Rotate(forward);

	void UseSkill(int skillIndex)
	{
		Skill skillToCast = PlayerSkills.ElementAt(skillIndex).Key;
		if(PlayerSkills[skillToCast] >= 0)
		{
			return;
		}

		if(AbilityCaster.UseSkill(Player, PlayerSkills.ElementAt(skillIndex).Key, InputManager.LookDirection))
		{
			PlayerSkills[skillToCast] = skillToCast.cooldown;
		}
	}

}
