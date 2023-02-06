using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VFX;

public class AbsorbedElement : MonoBehaviour
{
	public UnityEvent onAbsorbingElement;
	[SerializeField] Transform target;
	Element element;
	VisualEffect vfx;

	void Awake() => vfx =  GetComponent<VisualEffect>();

	public void GetAbsorbed(Element element)
	{
		this.element = element;
		(PlayerController.Instance.Player as IElementHolder).Regen(element);
		Destroy(gameObject, 3);
	}
	
	void Update() => target.transform.position = PlayerController.Instance.transform.position;
}
