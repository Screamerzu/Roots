using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BystanderManager))]
public class BystanderManagerEditor : Editor
{
	#region Colors
	Color bystandersGizmosColor = new Color(0, 0, 1, 0.5f);
	Color unspawnableDiskColor = new Color(0, 0, 0, 0.3f);
	Color spawnableDiskColor = new Color(0, 1, 0, 0.1f);
	#endregion

	SerializedProperty numberOfBystanders;
	SerializedProperty minRadius;
	SerializedProperty maxRadius;
	SerializedProperty bystanderPrefab;
	SerializedProperty bystandersPreCoordinates;
	SerializedProperty bystanders;
	Camera camera;

	void OnEnable()
	{
		camera = Camera.main;
		numberOfBystanders = serializedObject.FindProperty("numberOfBystanders");
		minRadius = serializedObject.FindProperty("minRadius");
		maxRadius = serializedObject.FindProperty("maxRadius");
		bystanderPrefab = serializedObject.FindProperty("bystanderPrefab");
		bystandersPreCoordinates = serializedObject.FindProperty("bystandersPreCoordinates");
		bystanders = serializedObject.FindProperty("bystanders");
	}

	void OnSceneGUI()
	{
		serializedObject.Update();
		DrawDiscArea();
		DrawBystanders();
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		EditorGUILayout.PropertyField(numberOfBystanders);
		EditorGUILayout.PropertyField(minRadius);
		EditorGUILayout.PropertyField(maxRadius);
		EditorGUILayout.PropertyField(bystanderPrefab);
		GUI.enabled = false;
		if(Application.isPlaying)
		{
			EditorGUILayout.PropertyField(bystanders);
		}
		else
		{
			EditorGUILayout.PropertyField(bystandersPreCoordinates);
		}

		GUI.enabled = true;
		if(GUILayout.Button("Randomize"))
		{
			(target as BystanderManager).Randomize();
		}

		serializedObject.ApplyModifiedProperties();
	}
	
	void DrawDiscArea()
	{
		Vector3 center = (target as MonoBehaviour).transform.position;
		Handles.zTest = UnityEngine.Rendering.CompareFunction.Less;
		Handles.color = spawnableDiskColor;
		Handles.DrawSolidDisc(center, Vector3.up, maxRadius.floatValue);
		Handles.color = unspawnableDiskColor;
		Handles.DrawSolidDisc(center, Vector3.up, minRadius.floatValue);
	}

	void DrawBystanders()
	{
		Handles.color = bystandersGizmosColor;

		for (int i = 0; i < bystandersPreCoordinates.arraySize; i++)
		{
			Handles.DrawSolidDisc(bystandersPreCoordinates.GetArrayElementAtIndex(i).vector3Value, Vector3.up, 0.5f);
		}
	}


}
