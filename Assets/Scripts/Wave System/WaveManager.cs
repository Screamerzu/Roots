using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class WaveManager : MonoBehaviour
{
	public static UnityEvent OnWaveStart;
	[SerializeField] List<Wave> Waves = new();
	[SerializeField] Vector2 spawnSize;
	[SerializeField][ReadOnly] int currentWaveIndex = 0;

	void OnDrawGizmos()
	{
		Color color = Color.green;
		color.a = 0.5f;
		Gizmos.color = color;
		Gizmos.DrawCube(transform.position, new Vector3(spawnSize.x, 0.1f, spawnSize.y));
	}

	[Button]
	public void StartWaves() => StartCoroutine(SpawnRoutine());

	IEnumerator SpawnRoutine()
	{
		while(true)
		{
			SpawnCurrentWave();
			yield return new WaitUntil(() => !Waves[currentWaveIndex].IsDone());

			currentWaveIndex ++;
			if(currentWaveIndex >= Waves.Count)
			{
				yield break;
			}
		}
	}

	void SpawnCurrentWave() => StartCoroutine(Waves[currentWaveIndex].Spawn(transform.position, spawnSize));

	[Button]
	[ContextMenu("Add Wave")]
	void AddWave()
	{
		Wave newWave = new Wave();
		newWave.name = "Wave: " + Waves.Count.ToString();
		Waves.Add(newWave);
	}
}
