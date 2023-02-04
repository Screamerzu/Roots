using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Ability
{
	public UnityEvent<IElementHolder, Ability> onFinishedCasting = new();
	public string AnimationStateName{ get; set; }
	public abstract void StartCasting(Vector3 direction, IElementHolder instigator);
}
