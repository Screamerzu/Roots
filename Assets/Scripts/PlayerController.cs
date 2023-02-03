using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(Motor))]
[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
	static readonly Dictionary<Skill, float> PlayerSkills = new()
	{ 
		{ Skill.Source, 0 },
		{ Skill.Transpose, 0 },
		{ Skill.Dash, 0 },
		{ Skill.Commit, 0 },
	};

	static readonly Dictionary<Element, Attack> PlayerAttacks = new()
	{ 
		{ Element.Default, Attack.DefaultAttack },
		{ Element.Earth, Attack.EarthAttack },
		{ Element.Fire, Attack.FireAttack },
		{ Element.Water, Attack.WaterAttack },
		{ Element.Wind, Attack.WaterAttack },
	};

	[SerializeField] AbilityCaster abilityCaster;
	public AbilityCaster AbilityCaster => abilityCaster;
	Player player;
	InputManager inputManager;
	Motor motor;

	void Awake()
	{
		player = GetComponent<Player>();
		inputManager = GetComponent<InputManager>();
		motor = GetComponent<Motor>();
		AbilityCaster.WithSkills(PlayerSkills).WithAttacks(PlayerAttacks);
	}

	void OnEnable()
	{
		inputManager.onShoot.AddListener(AttackCurrentElement);
		inputManager.onSkillUsed.AddListener(UseSkill);
	}

	void OnDisable()
	{
		inputManager.onShoot.RemoveListener(AttackCurrentElement);
		inputManager.onSkillUsed.RemoveListener(UseSkill);
	}

	void Update()
	{
		UpdateMovement(inputManager.MoveValue);
		AbilityCaster.UpdateCooldowns();
	}

	void FixedUpdate() => UpdateRotation(inputManager.LookDirection);
	
	void AttackCurrentElement() => AbilityCaster.Attack(player, player.CurrentElementHeld, inputManager.LookDirection);

	void UpdateMovement(Vector2 direction) => motor.Move(direction * Time.deltaTime);

	void UpdateRotation(Vector3 forward)
	{
		transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
		transform.eulerAngles = new Vector3(0, transform.eulerAngles.y,0);
	}

	void UseSkill(int skillIndex)
	{
		Skill skillToCast = PlayerSkills.ElementAt(skillIndex).Key;
		if(PlayerSkills[skillToCast] >= 0)
		{
			return;
		}

		if(AbilityCaster.UseSkill(player, PlayerSkills.ElementAt(skillIndex).Key, inputManager.LookDirection))
		{
			PlayerSkills[skillToCast] = skillToCast.cooldown;
		}
	}

}
