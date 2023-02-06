using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[RequireComponent(typeof(InputManager))]
public class CameraController : MonoBehaviour
{
	[SerializeField] float sensitivity = 1;
	[SerializeField] float zoomSensitivity = 1;
	[SerializeField][MinMaxSlider(-10, 10)] Vector2 zoomLimits;
	[SerializeField] Transform centerOfRotation;
	InputManager inputManager;
	float zoomedDistance;

	void Awake() => inputManager = GetComponent<InputManager>();
	void Update()
	{
		HandleZooming();
		HandlePanning();
	}

	void HandlePanning()
	{
		if(!inputManager.IsSpanKeyDown())
		{
			return;
		}

		Vector2 mouseMovementValue = inputManager.MouseMovementValue;

		transform.RotateAround(centerOfRotation.position, Vector3.up, sensitivity * mouseMovementValue.x * Time.deltaTime );
		transform.eulerAngles += sensitivity * Vector3.left * mouseMovementValue.y * Time.deltaTime;
	}

	void HandleZooming()
	{
		float previousZoomedDistance = zoomedDistance;
		zoomedDistance += Time.deltaTime * zoomSensitivity * inputManager.MouseScrollDelta;
		zoomedDistance = Mathf.Clamp(zoomedDistance, zoomLimits.x, zoomLimits.y);
		transform.position += transform.forward * (zoomedDistance - previousZoomedDistance);
	}
}
