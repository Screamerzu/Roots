using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class AIAction
{
	[SerializeField] int priority;
	public int Priority => priority;

	public virtual void Initialize(AIController controller){}
	public virtual bool PerformLoop(AIController controller) => false;
	public virtual void Finalize(AIController controller){}

	public virtual bool CanPerform(AIController controller) => true;
}
