using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class InputManager : MonoBehaviour
{
	[SerializeField] KeyCode shootKey = KeyCode.Mouse0;
	[SerializeField] KeyCode ability1Key = KeyCode.Q;
	[SerializeField] KeyCode ability2Key = KeyCode.E;
	[SerializeField] KeyCode ability3Key = KeyCode.Space;
	[SerializeField] KeyCode ability4Key = KeyCode.F;

	public Vector2 MoveValue => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	[Foldout("Actions")] public UnityEvent onShoot;
	[Foldout("Actions")] public UnityEvent onAbility1Used;
	[Foldout("Actions")] public UnityEvent onAbility2Used;
	[Foldout("Actions")] public UnityEvent onAbility3Used;
	[Foldout("Actions")] public UnityEvent onAbility4Used;

	void Update()
	{
		if(Input.GetKeyDown(shootKey))
		{
			onAbility1Used?.Invoke();
		}
		
		if(Input.GetKeyDown(ability1Key))
		{
			onAbility1Used?.Invoke();
		}

		if(Input.GetKeyDown(ability2Key))
		{
			onAbility2Used?.Invoke();
		}

		if(Input.GetKeyDown(ability3Key))
		{
			onAbility3Used?.Invoke();
		}

		if(Input.GetKeyDown(ability4Key))
		{
			onAbility4Used?.Invoke();
		}
	}
}
