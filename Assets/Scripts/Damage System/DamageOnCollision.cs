using UnityEngine;
using UnityEngine.Events;

public class DamageOnCollision : DamageDealer
{
	public UnityEvent onDamageDealt;
	[SerializeField] int damageAmount;
	[SerializeField] Element element;
	[SerializeField] GameObject ImpactVFX;

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
	public DamageOnCollision ThenSelfDestructImmediately()
	{
		onDamageDealt.AddListener(SelfDestruct);
		return this;
	}
	public DamageOnCollision ThenSelfDestructIn(float time)
	{
		onDamageDealt.AddListener( () => SelfDestructAfter(time) );
		return this;
	}

	void SelfDestructAfter(float time)
	{
		onDamageDealt.RemoveAllListeners();
		Destroy(gameObject, time);
	}

	void HandleImpact()
	{
		foreach (var collider in GetComponents<Collider>())
		{
			collider.enabled = false;
		}

		if(!ImpactVFX)
		{
			return;
		}

		Instantiate(ImpactVFX, transform.position, transform.rotation);
	}

	void SelfDestruct() => SelfDestructAfter(0);
	
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
			
			HandleImpact();
			DealDamageToTarget(player, damageAmount, element);
			onDamageDealt?.Invoke();
		}
		else if(other.TryGetComponent<Enemy>(out Enemy enemy))
		{
			if(!IsTargetValid(enemy))
			{
				return;
			}

			HandleImpact();
			DealDamageToTarget(enemy, damageAmount, element);
			onDamageDealt?.Invoke();
		}
	}
}
