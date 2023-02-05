using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class Enemy : MonoBehaviour, IDamageable, IElementHolder
{
	public static UnityEvent<Enemy> OnEnemyDied = new();
	[SerializeField] int currentElementHeldIndex = 0;
	public Element CurrentElementHeld 
	{ 
		get => Element.All[currentElementHeldIndex]; 
		set
		{
			for (int i = 0; i < Element.All.Length; i++)
			{
				if(Element.All[i] == value)
				{
					currentElementHeldIndex = i;
					break;
				}
			}
		}
	}
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
			Destroy(gameObject);
		}
	}
}
