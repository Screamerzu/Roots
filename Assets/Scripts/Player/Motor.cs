using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
	[SerializeField] float speed;

	public void Move(Vector3 direction) => transform.position += direction * speed;

	public void Rotate(Vector3 forward)
	{
		transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
		transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
	}
}
