using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class WaveViewer : MonoBehaviour
{
	TMP_Text textComponent;

	void Awake() => textComponent = GetComponent<TMP_Text>();

	void OnEnable() => WaveManager.OnWaveStart.AddListener(UpdateWaveText);
	void OnDisable() => WaveManager.OnWaveStart.RemoveListener(UpdateWaveText);

	void UpdateWaveText(int waveNumber)
	{
		textComponent.text = $"Wave: {waveNumber}";
	}
}
