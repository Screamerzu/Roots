using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class Enemy : MonoBehaviour, IDamageable, IElementHolder
{
	public static UnityEvent<Enemy> OnEnemyDied = new();
	public Element CurrentElementHeld { get; set; } = Element.Default;
	[SerializeField] int maxHealth = 3;
	[SerializeField] int health;
	public UnityEvent<Element> OnElementHeldChanged { get; set; }

	void Awake() => health = maxHealth;

	public void Damage(int value, Element element)
	{
		int lostValue = value;
		if(CurrentElementHeld.IsDominatedBy(element))
		{
			lostValue *= IDamageable.DAMAGE_MULTIPLIER;
			DamageDealer.OnPerfectDamageDealt?.Invoke(lostValue);
		}

		health -= lostValue;
		if(health <= 0)
		{
			OnEnemyDied?.Invoke(this);
		}
	}
}