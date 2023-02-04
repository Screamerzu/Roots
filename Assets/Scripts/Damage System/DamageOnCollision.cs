using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class DamageOnCollision : DamageDealer
{
	[SerializeField] int damageAmount;
	[SerializeField] Element element;
	[SerializeField] UnityEvent onDamageDealt;

	public DamageOnCollision Deal(int damageAmount)
	{
		this.damageAmount = damageAmount;
		return this;
	}
	public DamageOnCollision OfElement(Element element)
	{
		this.element = element;
		return this;
	}
	public DamageOnCollision OnTrigger()
	{
		GetComponent<Collider>().isTrigger = true;
		return this;
	}
	public DamageOnCollision OnCollision()
	{
		GetComponent<Collider>().isTrigger = false;
		return this;
	}
	public DamageOnCollision ThenSelfDestruct()
	{
		onDamageDealt.AddListener(SelfDestruct);
		return this;
	}


	void SelfDestruct()
	{
		onDamageDealt.RemoveAllListeners();
		Destroy(gameObject);
	}
	
	void OnTriggerEnter(Collider other)
	{
		DamageCheck(other.transform);
	}

	void OnCollisionEnter(Collision other)
	{
		DamageCheck(other.transform);
	}

	void DamageCheck(Transform other)
	{
		if(other.TryGetComponent<Player>(out Player player))
		{
			if(!IsTargetValid(player))
			{
				return;
			}

			DealDamageToTarget(player, damageAmount, element);
			onDamageDealt?.Invoke();
		}
		else if(other.TryGetComponent<Enemy>(out Enemy enemy))
		{
			if(!IsTargetValid(enemy))
			{
				return;
			}

			DealDamageToTarget(player, damageAmount, element);
			onDamageDealt?.Invoke();
		}
	}
}
