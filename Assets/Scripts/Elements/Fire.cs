using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Element
{
	protected override Element[]  SuperiorElements => new Element[]{ Water, SuperiorToAll };
}
