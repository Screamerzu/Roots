using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class AbsorbedElement : MonoBehaviour
{
	[SerializeField] Transform target;
	Element element;
	VisualEffect vfx;

	void Awake() => vfx =  GetComponent<VisualEffect>();

	public void GetAbsorbed(Element element)
	{
		this.element = element;
		StartCoroutine(RegenRoutine());
	}
	
	void Update()
	{
		target.transform.position = PlayerController.Instance.transform.position;
	}

	IEnumerator RegenRoutine()
	{
		yield return new WaitForSeconds(1);
		(PlayerController.Instance.Player as IElementHolder).Regen(element);
		yield return new WaitForSeconds(3);
		Destroy(gameObject);
	}
}
