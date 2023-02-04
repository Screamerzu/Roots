using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] float speed;
	public void SetSpeed(float speed) => this.speed = speed;
	void Update() => transform.position += transform.forward * Time.deltaTime * speed;
}
