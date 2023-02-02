using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Events;

public class Player : MonoBehaviour, IDamageable, IElementHolder
{
	[SerializeField] int maxHealth = 3;
	[SerializeField][ReadOnly] int health;
	[SerializeField][ReadOnly] Element elementHeld = Element.Default;
	[SerializeField] UnityEvent<Element> onElementHeldChanged;

	public Element CurrentElementHeld { get => elementHeld; set => elementHeld = value; }
	public UnityEvent<Element> OnElementHeldChanged { get => onElementHeldChanged; set => onElementHeldChanged = value; }

	void Awake() => health = maxHealth;

	public void Damage(int value, Element element)
	{
		health -= value;
	}
}
