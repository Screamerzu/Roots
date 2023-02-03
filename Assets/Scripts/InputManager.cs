using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class InputManager : MonoBehaviour
{
	[SerializeField] LayerMask floorMask;
	[SerializeField] float buffer = 0;
	[SerializeField] KeyCode shootKey = KeyCode.Mouse0;
	[SerializeField] KeyCode ability1Key = KeyCode.Q;
	[SerializeField] KeyCode ability2Key = KeyCode.E;
	[SerializeField] KeyCode ability3Key = KeyCode.Space;
	[SerializeField] KeyCode ability4Key = KeyCode.F;

	public Vector2 MoveValue => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	public Vector2 MouseMovementValue => new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
	public Vector3 MousePosition => Input.mousePosition;
	public Vector3 MousePositionLevelWithPlayer
	{
		get
		{
			Ray ray = camera.ScreenPointToRay(MousePosition);
			if(Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, layerMask: floorMask))
			{
				return new Vector3(hitInfo.point.x, 0, hitInfo.point.z);
			}

			return default;
		}
	}
	public Vector3 LookDirection => MousePositionLevelWithPlayer - transform.position;

	[Foldout("Actions")] public UnityEvent onShoot = new();
	[Foldout("Actions")] public UnityEvent<int> onSkillUsed = new();
	new Camera camera;
	void Awake() => camera = Camera.main;

	void Update()
	{
		if(Input.GetKeyDown(shootKey))
		{
			onShoot?.Invoke();
		}
		
		if(Input.GetKeyDown(ability1Key))
		{
			onSkillUsed?.Invoke(0);
		}

		if(Input.GetKeyDown(ability2Key))
		{
			onSkillUsed?.Invoke(1);
		}

		if(Input.GetKeyDown(ability3Key))
		{
			onSkillUsed?.Invoke(2);
		}

		if(Input.GetKeyDown(ability4Key))
		{
			onSkillUsed?.Invoke(3);
		}
	}
}
