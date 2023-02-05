using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IElementHolder))]
public class ElementSource : MonoBehaviour
{
	const string FIRE_ELEMENT_ABSORPTION_PREFAB_NAME = "FireAbsorption";
	const string WATER_ELEMENT_ABSORPTION_PREFAB_NAME = "WaterAbsorption";
	const string WIND_ELEMENT_ABSORPTION_PREFAB_NAME = "WindAbsorption";
	const string EARTH_ELEMENT_ABSORPTION_PREFAB_NAME = "EarthAbsorption";
	AbsorbedElement Prefab
	{
		get
		{
			string prefabName = string.Empty;
			if(elementHolder.CurrentElementHeld == Element.Fire)
			{
				prefabName = FIRE_ELEMENT_ABSORPTION_PREFAB_NAME;
			}
			else if(elementHolder.CurrentElementHeld == Element.Water)
			{
				prefabName = WATER_ELEMENT_ABSORPTION_PREFAB_NAME;
			}
			else if(elementHolder.CurrentElementHeld == Element.Wind)
			{
				prefabName = WIND_ELEMENT_ABSORPTION_PREFAB_NAME;
			}
			else if(elementHolder.CurrentElementHeld == Element.Earth)
			{
				prefabName = EARTH_ELEMENT_ABSORPTION_PREFAB_NAME;
			}
			
			return Resources.Load<AbsorbedElement>(prefabName);
		}
	}
	IElementHolder elementHolder;

	void Awake() => elementHolder = GetComponent<IElementHolder>();

	void OnEnable() => Enemy.OnEnemyDied.AddListener(SpawnVFX);

	void OnDisable() => Enemy.OnEnemyDied.RemoveListener(SpawnVFX);
	
	void SpawnVFX(Enemy enemy)
	{
		if(this.elementHolder as Enemy != enemy)
		{
			return;
		}
		
		Instantiate(Prefab, enemy.transform.position, Quaternion.identity).GetAbsorbed(enemy.CurrentElementHeld);
	}

}
