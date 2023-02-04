using UnityEngine;

public class HUDBootstrapper : MonoBehaviour
{
	const string HUD_PREFAB_NAME = "HUD";
	GameObject HUDPrefab => Resources.Load<GameObject>("HUD");

	void Awake() => Instantiate(HUDPrefab, transform);
}
