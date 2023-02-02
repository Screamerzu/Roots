using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IElementHolder
{
	Element CurrentElementHeld { get; set; }
	UnityEvent<Element> OnElementHeldChanged { get; set; }

	void Consume(Element element) => CurrentElementHeld = Element.Default;
	void Regen(Element element) => CurrentElementHeld = element;
}
