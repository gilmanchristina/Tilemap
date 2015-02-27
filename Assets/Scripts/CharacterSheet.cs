using UnityEngine;
using System.Collections;

public class CharacterSheet : MonoBehaviour {

	public string username = "";
	void OnGUI(){
		username = GUI.TextArea(new Rect(240,20,75,20), username);
	}
}
