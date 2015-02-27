//using UnityEngine;
//using UnityEditor;
//using System.Collections;
//using System.IO;
//
//[CustomEditor(typeof(Grid))]
//public class GridEditor : Editor {
//	Grid grid;
//	private int oldIndex = 0;
//
//	void OnEnable()
//	{
//
//		grid = (Grid)target;
//
//	}
//	[MenuItem("Assets/Create/TileSet")]
//	static void CreateTileSet()
//	{
//		var asset = ScriptableObject.CreateInstance<TileSet> ();
//		var path = AssetDatabase.GetAssetPath (Selection.activeObject);
//
//		if (string.IsNullOrEmpty (path))
//		{
//			path = "Assets";
//		}
//		else if (Path.GetExtension(path) != "")
//		{
//			path = path.Replace (Path.GetFileName(path), "");
//
//		}
//		else
//		{
//			path +="/";
//		}
//
//		var assetPathandName = AssetDatabase.GenerateUniqueAssetPath (path + "TileSet.asset");
//		AssetDatabase.CreateAsset (asset, assetPathandName);
//		AssetDatabase.SaveAssets ();
//		EditorUtility.FocusProjectWindow ();
//		Selection.activeObject = asset;
//		asset.hideFlags = HideFlags.DontSave;
//	}
//
//	public override void OnInspectorGUI()
//	{
//		grid.width = createSlider ("Width", grid.width);
//		grid.height = createSlider ("Height", grid.height);
//
//		//Tile Prefab
//		EditorGUI.BeginChangeCheck ();
//		var newTilePrefab = (Transform)EditorGUILayout.ObjectField("Tile Prefab", grid.tilePrefab, typeof(Transform), false);
//		if(EditorGUI.EndChangeCheck())
//		{
//			grid.tilePrefab = newTilePrefab;
//			Undo.RecordObject (target, "Grid Changed");
//
//		}
//		//Tile Map
//
//		EditorGUI.BeginChangeCheck ();
//		var newTileSet = (TileSet)EditorGUILayout.ObjectField ("Tileset", grid.tileSet, typeof(TileSet), false);
//		if (EditorGUI.EndChangeCheck ())
//		{
//			grid.tileSet = newTileSet;
//			Undo.RecordObject(target, "Grid Changed");
//		}
//		if (grid.tileSet != null)
//		{
//			EditorGUI.BeginChangeCheck ();
//			var names = new string[grid.tileSet.prefabs.Length];
//			var values = new int[names.Length];
//			for (int i= 0; i < names.Length; i++)
//			{
//				names [i] = grid.tileSet.prefabs [i] != null ? grid.tileSet.prefabs [i].name : "";
//				values [i] = i; 
//			}
//
//		var index = EditorGUILayout.IntPopup ("Select Tile", oldIndex, names, values);
//
//		if (EditorGUI.EndChangeCheck ())
//		{
//			Undo.RecordObject (target, "Grid Changed");
//			if (oldIndex != index)
//			{
//				oldIndex = index;
//				grid.tilePrefab = grid.tileSet.prefabs [index];
//
//				float width = grid.tilePrefab.renderer.bounds.size.x;
//				float height = grid.tilePrefab.renderer.bounds.size.y;
//				
//					grid.width = width;
//					grid.height = height;
//			}
//		}
//	}
//}
//
//	
//	void OnSceneGUI()
//	{
//		int controlid = GUIUtility.GetControlID (FocusType.Passive);
//		Event e = Event.current;
//		Ray ray = Camera.current.ScreenPointToRay (new Vector3 (e.mousePosition.x, -e.mousePosition.y + Camera.current.pixelHeight));
//		Vector3 mousePos = ray.origin;
//
//		if (e.isMouse && e.type == EventType.MouseDown && e.button == 0)
//		{
//			GUIUtility.hotControl = controlid;
//			e.Use (); //make sure it not twice used.
//			GameObject gameObject;
//			Transform prefab = grid.tilePrefab;
//
//			if(prefab)
//			{
//				Undo.IncrementCurrentGroup();
//				gameObject = (GameObject) PrefabUtility.InstantiatePrefab(prefab.gameObject);
//				Vector3 aligned = new Vector3(Mathf.Floor(mousePos.x/grid.width)*grid.width + grid.width/2.0f, Mathf.Floor(mousePos.y/grid.height) *grid.height + grid.height/2.0f, 0.0f);
//
//				if(GetTransformFromPosition(aligned) != null)return;
//				gameObject.transform.position = aligned;
//				gameObject.transform.parent = grid.transform;
//				Undo.RegisterCreatedObjectUndo(gameObject, "Create" + gameObject.name);
//			}
//		}
//
//		if (e.isMouse && e.type == EventType.MouseDown && e.button == 1)
//		{
//			GUIUtility.hotControl = controlid;
//			e.Use ();
//			Vector3 aligned = new Vector3(Mathf.Floor(mousePos.x/grid.width)*grid.width + grid.width/2.0f, Mathf.Floor(mousePos.y/grid.height) *grid.height + grid.height/2.0f, 0.0f);
//			Transform transform = GetTransformFromPosition(aligned);
//			if(transform != null)
//			{
//				DestroyImmediate( transform.gameObject);
//			}
//		}
//
//		if (e.isMouse && e.type == EventType.MouseUp)
//		{
//			GUIUtility.hotControl = 0;
//		}
//	}
//	Transform GetTransformFromPosition(Vector3 aligned)
//	{
//		int i = 0;
//		while (i < grid.transform.childCount)
//		{
//			Transform transform = grid.transform.GetChild(i);
//			if(transform.position == aligned)
//			{
//				return transform;
//			}
//			i++;
//		}
//		return null;
//	}
//	private float createSlider(string labelName, float sliderPoition)
//	{
//		GUILayout.BeginHorizontal ();
//		GUILayout.Label ("Grid" + labelName);
//		sliderPoition = EditorGUILayout.Slider (sliderPoition,1f, 100f,null);
//		GUILayout.EndHorizontal ();
//
//		return sliderPoition;
//	}
//
//}
