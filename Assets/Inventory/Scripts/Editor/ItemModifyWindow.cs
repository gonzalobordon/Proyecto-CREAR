using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemModifyWindow : EditorWindow {
	private static Database database;
	private static EditorWindow window;

	private static Item databaseItem;
	private static Item newItem;
	private GUILayoutOption[] options = {GUILayout.MaxWidth(150.0f),GUILayout.MinWidth(20.0f)};
	public static void ShowItemWindow(Database db, Item item)
	{
		database = db;
		window = GetWindow<ItemModifyWindow>();
		window.maxSize = new Vector2(300,250);
		window.minSize = new Vector2(300,250);
		databaseItem = item;
		newItem = new Item();
		newItem.id = item.id;
		newItem.name = item.name;
		newItem.cost = item.cost;
		newItem.description = item.description;
	}

	public void OnGUI()
	{
		DisplayItem(newItem);
		if(GUILayout.Button("Modificar"))
		{
			ModifyItem();
		}
	}

	private bool shouldDisable;
	private void DisplayItem(Item item)
	{
		GUIStyle textAreaStyle = new GUIStyle(GUI.skin.textArea);
		textAreaStyle.wordWrap = true;

		GUIStyle valueStyle = new GUIStyle(GUI.skin.label);
		valueStyle.wordWrap = true;
		valueStyle.alignment = TextAnchor.MiddleLeft;
		valueStyle.fixedWidth = 50;
		valueStyle.margin = new RectOffset(0,100,0,0);

		if (database.FindItemInDatabase(item.id)==null)
		{
			shouldDisable = false;
		}else shouldDisable = true;

		EditorGUILayout.BeginVertical("Box");

		
		EditorGUILayout.BeginHorizontal();
		GUILayout.Label("Nombre: ");
		item.name = EditorGUILayout.TextField(item.name, options);
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();
		GUILayout.Label("Costo: ");
		item.cost = EditorGUILayout.IntField(item.cost, options);
		EditorGUILayout.EndHorizontal();

		//item.scrollPos = EditorGUILayout.BeginScrollView(item.scrollPos,GUILayout.MinHeight(3),GUILayout.MinHeight(50));
		GUILayout.Label("Descripcion: ");
		item.description = EditorGUILayout.TextArea(item.description, textAreaStyle,GUILayout.MinHeight(100));
		//EditorGUILayout.EndScrollView();

	}

	private void ModifyItem()
	{
		Undo.RecordObject(database, "Item Modified");
		databaseItem.name = newItem.name;
		databaseItem.cost = newItem.cost;
		databaseItem.description = newItem.description;
		EditorUtility.SetDirty(database);
		window.Close();
	}

}