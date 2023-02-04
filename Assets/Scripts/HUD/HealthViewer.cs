using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthViewer : MonoBehaviour
{
	Image fillImage;

	void Awake() => fillImage = GetComponent<Image>();

	void OnEnable() => Player.OnPlayerHealthChanged.AddListener(UpdateHealthText);
	void OnDisable() => Player.OnPlayerHealthChanged.RemoveListener(UpdateHealthText);

	void UpdateHealthText(int health) => fillImage.fillAmount = health / PlayerController.Instance.Player.MaxHealth;
}
