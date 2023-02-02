using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : Ability
{
	public static readonly Commit Commit = new();
	public static readonly Dash Dash = new();
	public static readonly Source Source = new();
	public static readonly Transpose Transpose = new();

	public float cooldown { get; protected set; }
}
