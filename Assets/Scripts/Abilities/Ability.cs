using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability
{
    public delegate void OnFinishedCasting();
	protected OnFinishedCasting onFinishedCasting;
	public abstract OnFinishedCasting StartCasting(Vector3 direction, IElementHolder instigator);
}
