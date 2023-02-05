using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : Element
{
	protected override Element[] SuperiorElements => new Element[]{ Fire, SuperiorToAll };
}
