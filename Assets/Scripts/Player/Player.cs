using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Events;

public class Player : MonoBehaviour, IDamageable, IElementHolder
{
	public static UnityEvent<int> OnPlayerHealthChanged = new();
	public static UnityEvent OnPlayerDied = new();
	public int MaxHealth => maxHealth;
	[SerializeField] int maxHealth = 3;
	[SerializeField][ReadOnly] int health;
	[SerializeField][ReadOnly] Element elementHeld = Element.Default;
	[SerializeField] UnityEvent<Element> onElementHeldChanged;

	public Element CurrentElementHeld { get => elementHeld; set => elementHeld = value; }
	public UnityEvent<Element> OnElementHeldChanged { get => onElementHeldChanged; set => onElementHeldChanged = value; }

	void Awake() => Heal();

	public void Damage(int value, Element element)
	{
		health = Mathf.Clamp(health - value, 0 , maxHealth);
		OnPlayerHealthChanged?.Invoke(health);
		if(health <= 0)
		{
			OnPlayerDied?.Invoke();
		}
	}

	void Heal()
	{
		health = maxHealth;
		OnPlayerHealthChanged?.Invoke(health);
	}

	[Button]
	void ShowElementHeld() => Debug.Log(CurrentElementHeld);
}
