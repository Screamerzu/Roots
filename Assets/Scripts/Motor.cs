using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Motor : MonoBehaviour
{
	[SerializeField] float speed;
	[SerializeField] float jumpForce;
	[SerializeField] int numberOfJumps;
	new Rigidbody rigidbody;
	int numberOfJumpsRemaining;

	void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
		numberOfJumpsRemaining = numberOfJumps;
	}

	public void Jump()
	{
		if(numberOfJumpsRemaining <= 0)
		{
			return;
		}
		numberOfJumpsRemaining--;

		rigidbody.AddForce(Vector3.up * jumpForce);
	}

	public void Move(Vector2 direction)
	{
		rigidbody.velocity = new Vector3(direction.x, 0, direction.y).normalized * speed;
	}

	public void Rotate(Vector2 forward)
	{
		transform.forward = forward;
	}
}
