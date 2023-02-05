using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Element
{
	static Element defaultElement = new Default();
	static Element fireElement = new Fire();
	static Element windElement = new Wind();
	static Element earthElement = new Earth();
	static Element waterElement = new Water();
	static Element superiorElement = new SuperiorToAll();
	static List<Element> all = new(){ defaultElement, fireElement, windElement, earthElement, waterElement, superiorElement };

	public static Element Default => defaultElement;
	public static Element Fire => fireElement;
	public static Element Wind => windElement;
	public static Element Earth => earthElement;
	public static Element Water => waterElement;
	public static Element SuperiorToAll => superiorElement;
	public static Element[] All => all.ToArray();
	
	protected abstract Element[] SuperiorElements{ get; }

	public bool IsDominatedBy(Element otherElement)
	{
		foreach (var superiorElement in SuperiorElements)
		{
			if(otherElement == superiorElement)
			{
				return true;
			}
		}

		return false;
	}
}
