using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[System.Serializable]
public class Wave
{
	[HideInInspector] public string name = string.Empty;
	[SerializeField] List<Enemy> enemies = new();
	public List<Enemy> CurrentEnemiesAlive { get; private set; } = new();

	public virtual IEnumerator Spawn(Vector3 midPoint, Vector2 spawnSize)
	{
		Enemy.OnEnemyDied.AddListener(ClearEnemyOnDeath);

		foreach (var enemy in enemies)
		{
			Vector3 randomPoint = new Vector3(Random.Range(0, spawnSize.x), 0, Random.Range(0, spawnSize.y));
			randomPoint += midPoint;
			Enemy newEnemy = GameObject.Instantiate<Enemy>(enemy, randomPoint, Quaternion.identity);
			CurrentEnemiesAlive.Add(newEnemy);
		}

		yield break;
	}

	public virtual bool IsDone() => CurrentEnemiesAlive.Count == 0;

	void ClearEnemyOnDeath(Enemy deadEnemy)
	{
		CurrentEnemiesAlive.Remove(deadEnemy);
		if(IsDone())
		{
			Enemy.OnEnemyDied.RemoveListener(ClearEnemyOnDeath);
		}
	}

}
