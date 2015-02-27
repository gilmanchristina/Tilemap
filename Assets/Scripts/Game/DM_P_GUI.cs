using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DM_P_GUI : MonoBehaviour {

	bool DM_UI;
	bool P_UI;
	public Unit unit;
	public ClickableTile clicktile;

	void OnGUI(){
		if (string.Compare (Application.loadedLevelName, "Board") != 0) {
						if (GUI.Button (new Rect (10, 100, 100, 25), "DM")) {
								DM_UI = true;
								P_UI = false;
						}
						if (GUI.Button (new Rect (10, 125, 100, 25), "Player")) {
								P_UI = true;
								DM_UI = false;
						}
						if (DM_UI == true) {
								if (GUI.Button (new Rect (10, 175, 100, 25), "Move")) {
										clicktile.MoveButton = true;
								}
								if (GUI.Button (new Rect (10, 200, 100, 25), "Attack")) {

								}
								if (GUI.Button (new Rect (10, 225, 100, 25), "Heal")) {

								}
								if (GUI.Button (new Rect (10, 250, 100, 25), "Kick")) {

								}
								if (GUI.Button (new Rect (10, 275, 100, 25), "Give")) {

								}
								if (GUI.Button (new Rect (10, 300, 100, 25), "Turn")) {
										unit.NextTurn ();
								}
						} else if (P_UI == true) {
								if (GUI.Button (new Rect (10, 175, 100, 25), "Move")) {
										clicktile.MoveButton = true;
								}
								if (GUI.Button (new Rect (10, 200, 100, 25), "Attack")) {

								}
								if (GUI.Button (new Rect (10, 225, 100, 25), "Enter")) {

								}
								if (GUI.Button (new Rect (10, 250, 100, 25), "Steal")) {

								}
								if (GUI.Button (new Rect (10, 275, 100, 25), "Trade")) {

								}
								if (GUI.Button (new Rect (10, 300, 100, 25), "Heal")) {

								}
								if (GUI.Button (new Rect (10, 325, 100, 25), "Turn")) {
										unit.NextTurn ();
								}

						}
				}
	}
}
