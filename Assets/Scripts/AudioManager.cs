using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance;
	[SerializeField] AudioClip backgroundMusic;

	AudioSource audioSource;

	void Awake()
	{
		Instance = this;
		audioSource = GetComponent<AudioSource>();
		audioSource.loop = true;
		if(backgroundMusic)
		{
			PlayMusic(backgroundMusic);
		}
	}

	public void PlayMusic(AudioClip backgroundMusic)
	{
		audioSource.clip = backgroundMusic;
		audioSource.Play();
	}

}
