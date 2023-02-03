using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Ability
{
	public UnityEvent<Ability> onFinishedCasting = new();
	public abstract void StartCasting(Vector3 direction, IElementHolder instigator);
}
