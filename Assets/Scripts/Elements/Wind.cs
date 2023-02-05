using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : Element
{
	protected override Element[] SuperiorElements => new Element[]{ Earth, SuperiorToAll };
}
