using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SkillViewer))]
[CanEditMultipleObjects]
public class SkillViewerEditor : Editor
{
	SerializedProperty skillIndex;

	void OnEnable() => skillIndex = serializedObject.FindProperty("skillIndex");

	public override void OnInspectorGUI()
	{
		serializedObject.Update();
		
		DrawSkillTypeSelection();

		serializedObject.ApplyModifiedProperties();
	}

	void DrawSkillTypeSelection()
	{
		string[] skillNames = Skill.All.Select( (skill) => skill.ToString() ).ToArray();
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("Skill");
		skillIndex.intValue = EditorGUILayout.Popup(skillIndex.intValue, skillNames);
		EditorGUILayout.EndHorizontal();
	}
}
