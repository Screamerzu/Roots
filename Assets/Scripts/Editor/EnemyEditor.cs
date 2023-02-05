using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Enemy))]
public class EnemyEditor : Editor
{
	Enemy enemy => target as Enemy;
	SerializedProperty currentElementHeldIndex;
	SerializedProperty health;
	SerializedProperty maxHealth;

	void OnEnable()
	{
		health = serializedObject.FindProperty("health");
		maxHealth = serializedObject.FindProperty("maxHealth");
		currentElementHeldIndex = serializedObject.FindProperty("currentElementHeldIndex");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		DrawElementTypeSelection();
		EditorGUILayout.PropertyField(maxHealth);
		GUI.enabled = false;
		EditorGUILayout.PropertyField(health);
		GUI.enabled = true;
		serializedObject.ApplyModifiedProperties();
	}

	void DrawElementTypeSelection()
	{
		string[] elementsNames = Element.All.Select( (element) => element.ToString() ).ToArray();
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("Element");
		currentElementHeldIndex.intValue = EditorGUILayout.Popup(currentElementHeldIndex.intValue, elementsNames);
		EditorGUILayout.EndHorizontal();
	}
}
