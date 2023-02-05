using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperiorToAll : Element
{
	protected override Element[] SuperiorElements => new Element[]{};
	
	public override string ToString() => "Source";
}
