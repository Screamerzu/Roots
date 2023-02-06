using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
	[SerializeField] float speed;
	Camera camera;

	void Awake() => camera = Camera.main;

	public void MoveRelativeToCamera(Vector3 direction)
	{
		Vector3 absoluteDirection = direction.x * camera.transform.right + direction.z * camera.transform.forward;
		absoluteDirection.y = 0;
		absoluteDirection.Normalize();
		Move(absoluteDirection);
	}
	public void Move(Vector3 direction) => transform.position += direction * speed * Time.deltaTime;

	public void Rotate(Vector3 forward)
	{
		transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
		transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
	}
}
