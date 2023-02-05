using UnityEngine;

[System.Serializable]
public abstract class Element
{
	public static readonly Element Default = new Default();
	public static readonly Element Fire = new Fire();
	public static readonly Element Wind = new Wind();
	public static readonly Element Earth = new Earth();
	public static readonly Element Water = new Water();
	public static readonly Element[] All  = { Default, Fire, Wind, Earth, Water };

	protected Element superiorElement;

	public string name;
	public bool IsDominatedBy(Element otherElement) => otherElement == superiorElement;
}
