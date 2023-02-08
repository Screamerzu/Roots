using UnityEngine;
using NaughtyAttributes;

public class RandomMovementAction : MoveAction
{
	[SerializeField] float movementRadius;
	public override void Initialize(AIController controller)
	{
		base.Initialize(controller);
		Vector3 randomPointOnUnitCircle = Random.insideUnitSphere * movementRadius;
		randomPointOnUnitCircle.y = controller.transform.position.y;
		
		target = randomPointOnUnitCircle + controller.transform.position;
	}
}
