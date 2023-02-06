using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IElementHolder
{
	Element CurrentElementHeld { get; set; }
	UnityEvent<Element> OnElementHeldChanged { get; set; }

	void Consume()
	{
		if(CurrentElementHeld == Element.Default)
		{
			return;
		}

		CurrentElementHeld = Element.Default;
		OnElementHeldChanged?.Invoke(CurrentElementHeld);
	}
	
	void Regen(Element element)
	{
		if(CurrentElementHeld == element)
		{
			return;
		}

		CurrentElementHeld = element;
		OnElementHeldChanged?.Invoke(CurrentElementHeld);
	}
}
