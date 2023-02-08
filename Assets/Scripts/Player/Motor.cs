using UnityEngine;
using UnityEngine.AI;
using NaughtyAttributes;

[RequireComponent(typeof(NavMeshAgent))]
public class Motor : MonoBehaviour
{
	[SerializeField] float speed;
	[SerializeField][Foldout("NavMesh Properties")] float followDistance;
	NavMeshAgent navMeshAgent;
	Camera camera;

	void Awake()
	{
		camera = Camera.main;
		navMeshAgent = GetComponent<NavMeshAgent>();
		navMeshAgent.speed = speed;
		navMeshAgent.stoppingDistance = followDistance;
	}

	public void MoveRelativeToCamera(Vector3 direction)
	{
		Vector3 absoluteDirection = direction.x * camera.transform.right + direction.z * camera.transform.forward;
		absoluteDirection.y = 0;
		absoluteDirection.Normalize();
		Move(absoluteDirection);
	}
	public void Move(Vector3 direction) => navMeshAgent.Move(direction * speed * Time.deltaTime);
	public void MoveTowards(Vector3 target) => navMeshAgent.SetDestination(target);
	public void Rotate(Vector3 forward)
	{
		transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
		transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
	}
}
