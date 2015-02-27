using UnityEngine;
using System.Collections;

public class savecreate : MonoBehaviour {
	public Save savObj;
	public string savename;
	//Board _Board = new Board();
	//public GameObject TilePrefab;
	ChangeScene _Menu = new ChangeScene();
	void OnGUI()
	{
		if (GUILayout.Button ( "New")) {
			//_Board.generateMap (TilePrefab);
			_Menu.ChangeToScene("Board");
		}
		if (GUILayout.Button ( "Load")) {
			savObj.LoadGame(savename);
				}
		if (GUILayout.Button ( "Save")) {
			_Menu.ChangeToScene("Board");
			savObj.SaveGame(savename);
		}

	}

}
