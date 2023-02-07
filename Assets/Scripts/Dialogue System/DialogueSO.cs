using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue")]
public class DialogueSO : ScriptableObject
{
	[SerializeField] AudioClip audioClip;
	[SerializeField] DialogueMessage[] messages;

	public AudioClip AudioClip => audioClip;
	public DialogueMessage[] Messages => messages;
}
