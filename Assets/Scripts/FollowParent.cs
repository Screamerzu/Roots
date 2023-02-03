using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class FollowParent : MonoBehaviour
{
	Transform target;

	void Awake()
	{
		target = transform.parent;
		transform.SetParent(null);
		if(target is null)
		{
			enabled = false;
		}
	}

	void Update()
	{
		transform.position = target.position;
	}
}
