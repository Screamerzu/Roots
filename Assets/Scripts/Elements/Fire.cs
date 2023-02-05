using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Element
{
	public Fire()
	{
		superiorElement = Element.Water;
		name = "Fire";
	}
}
