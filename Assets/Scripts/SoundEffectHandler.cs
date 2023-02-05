using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectHandler : MonoBehaviour
{
	[SerializeField] AudioClip soundEffect;
	[SerializeField] [Range(0,1)] float volume;
	AudioSource audioSource;
	private void Awake()
	{
		audioSource = GameObject.FindObjectOfType<AudioSource>();
	}
	public void SpawnSoundEffect()
	{
		Debug.Log("Sound Effecto: " + soundEffect + " .. " + audioSource.name);
		audioSource.PlayOneShot(soundEffect,volume);
	}
}
