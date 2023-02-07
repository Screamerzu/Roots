using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class DialogueManager : MonoBehaviour
{
	public static DialogueManager Instance;
	const string DIALOGUES_PATH = "Dialogues";
	[SerializeField] GameObject root;
	[SerializeField] Image actorImageHolder;
	[SerializeField] TMPro.TMP_Text textComponent;
	AudioSource audioSource;
	DialogueSO currentDialogue;
	int currentMessageIndex;

	void Awake()
	{
		root.SetActive(false);
		audioSource = GetComponent<AudioSource>();
		Instance = this;
	}

	public void TriggerDialogue(string dialogueName)
	{
		currentDialogue = Resources.Load<DialogueSO>($"{DIALOGUES_PATH}/{dialogueName}");
		currentMessageIndex = 0;
		root.SetActive(true);
		Setup();
	}

	void Setup()
	{
		DialogueMessage currentMessage = currentDialogue.Messages[currentMessageIndex];
		actorImageHolder.sprite = currentMessage.actorImage;
		textComponent.text = currentMessage.message;
		if(currentMessage.audioClip)
		{
			audioSource.PlayOneShot(currentMessage.audioClip);
		}
	}

	public void Increment()
	{
		currentMessageIndex ++;
		if(currentMessageIndex >= currentDialogue.Messages.Length)
		{
			root.SetActive(false);
			return;
		}

		Setup();
	}
}
