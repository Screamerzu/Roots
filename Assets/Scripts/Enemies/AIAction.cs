using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[System.Serializable]
public abstract class AIAction
{
	[HideInInspector] public string name;
	[SerializeField] int priority;
	public int Priority => priority;

	protected AIAction() => name = GetType().ToString();
	public virtual void Initialize(AIController controller){}
	public virtual bool PerformLoop(AIController controller) => false;
	public virtual void Finalize(AIController controller){}

	public virtual bool CanPerform(AIController controller) => true;
}
