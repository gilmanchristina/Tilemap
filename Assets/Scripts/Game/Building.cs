using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

	Ray ray;
	bool ready = false;
	public RaycastHit hitInfo;
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if(Input.GetMouseButtonDown(0) && Physics.Raycast (ray, out hitInfo, Mathf.Infinity)){
			if(hitInfo.collider.gameObject.name == "Building(Clone)" && ready == true){
				Debug.Log("Ready For Entry");
				Application.LoadLevel(5);

			}
		}
	}

	void OnGUI(){
		if (GUI.Button (new Rect (100, 325, 100, 25), "Enter")) {
			//sdamage = GUI.TextArea (new Rect (100, 325, 100, 25), sdamage);
			ready = true;
		}
	}
}
