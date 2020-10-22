using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Database))]
public class DatabaseEditor : Editor {
	private Database database;
	private string searchString = "";
	private bool shouldSearch;
	private void OnEnable()
	{
		database = (Database)target;
	}
	public override void OnInspectorGUI()
	{
		//base.DrawDefaultInspector();
		if (database)
		{
			EditorGUILayout.BeginHorizontal("Box");
			GUILayout.Label("Items en la base de datos: " + database.items.Count);
			EditorGUILayout.EndHorizontal();

			if(database.items.Count>0)
			{
				EditorGUILayout.BeginHorizontal("Box");
				GUILayout.Label("Buscar: ");
				searchString = GUILayout.TextField(searchString);
				EditorGUILayout.EndHorizontal();
			}

			if(GUILayout.Button("Nuevo Item"))
			{
				//Debug.Log("crear nuevo item");
				ItemWindow.ShowEmptyWindow(database);
			}

			if(System.String.IsNullOrEmpty(searchString))
			{
				shouldSearch = false;
			}else shouldSearch = true;

			foreach (Item item in database.items)
			{
				if (shouldSearch)
				{
					if (item.name == searchString || item.name.Contains(searchString) || item.id.ToString() == searchString)
					{
						DisplayItem(item);
					}
				}
				else DisplayItem(item);
			}
			if (deletedItem!=null)
			{
				database.items.Remove(deletedItem);
			}
		}
	}

	private Item deletedItem;
	private void DisplayItem(Item item)
	{
		GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
		labelStyle.wordWrap = true;

		GUIStyle valueStyle = new GUIStyle(GUI.skin.label);
		valueStyle.wordWrap = true;
		valueStyle.alignment = TextAnchor.MiddleLeft;
		valueStyle.fixedWidth = 50;
		valueStyle.margin = new RectOffset(0,100,0,0);

		EditorGUILayout.BeginVertical("Box");

		EditorGUILayout.BeginHorizontal();
		GUILayout.Label("ID: ");
		GUILayout.Label(item.id.ToString(), valueStyle);
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();
		GUILayout.Label("Nombre: ");
		GUILayout.Label(item.name.ToString(), valueStyle);
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();
		GUILayout.Label("Costo: ");
		GUILayout.Label(item.cost.ToString(), valueStyle);
		EditorGUILayout.EndHorizontal();

		item.scrollPos = EditorGUILayout.BeginScrollView(item.scrollPos,GUILayout.MinHeight(3),GUILayout.MinHeight(50));
		GUILayout.Label("Descripcion: ");
		GUILayout.Label(item.description.ToString(), labelStyle);
		EditorGUILayout.EndScrollView();
		
		EditorGUILayout.BeginHorizontal();
		if (GUILayout.Button("Delete"))	
		{
			deletedItem = item;
		}else deletedItem = null;

		if (GUILayout.Button("Modificar"))
		{
			ItemModifyWindow.ShowItemWindow(database,item);
		}
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.EndVertical();
	}
}
