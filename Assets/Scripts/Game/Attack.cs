using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Attack : MonoBehaviour {
	string shealth;
	string sdamage;
	int health;
	int damage;
	Ray ray;
	bool ready = false;
	public RaycastHit hitInfo;
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if(Input.GetMouseButtonDown(0) && Physics.Raycast (ray, out hitInfo, Mathf.Infinity)){
			if(hitInfo.collider.gameObject.name == "Monster(Clone)" && ready == true){
				Debug.Log("Ready For Attack");
				shealth = hitInfo.collider.gameObject.GetComponent<MonsterData> ().Hit_dice.ToString();
				damage = 5;//int.Parse (sdamage);
				health = int.Parse(shealth);
				health = health - damage;
				hitInfo.collider.gameObject.GetComponent<MonsterData> ().Hit_dice = health.ToString();
				ready = false;
			}
		}
	}

	void OnGUI(){
		if (GUI.Button (new Rect (100, 300, 100, 25), "Attack")) {
			//sdamage = GUI.TextArea (new Rect (100, 325, 100, 25), sdamage);
			ready = true;
		}
	}
}