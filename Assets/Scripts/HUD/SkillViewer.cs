using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class SkillViewer : MonoBehaviour
{
	[SerializeField] int skillIndex = 0;
	TMP_Text textComponent;

	void Awake() => textComponent = GetComponent<TMP_Text>();
	void Update() => UpdateSkillCooldown();
	void UpdateSkillCooldown() => textComponent.text = $"{Mathf.CeilToInt(Mathf.Clamp(PlayerController.Instance.AbilityCaster.SkillCooldowns[Skill.All[skillIndex]], 0, Mathf.Infinity))}";
}
