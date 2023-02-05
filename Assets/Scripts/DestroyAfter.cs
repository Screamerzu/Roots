using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
	[SerializeField] float duration;
	void Awake() => Destroy(gameObject, duration);
}
