using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct DialogueMessage 
{
	public Sprite actorImage;
	public AudioClip audioClip;
	[TextArea] public string message;
}
