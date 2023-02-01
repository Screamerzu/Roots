using UnityEngine;

public abstract class Element
{
	public static readonly Element Default = new Default();
	public static readonly Element Fire = new Fire();
	public static readonly Element Wind = new Wind();
	public static readonly Element Earth = new Earth();
	public static readonly Element Water = new Water();

	protected Element superiorElement;

	public bool Dominates(Element otherElement) => otherElement == superiorElement;
}
