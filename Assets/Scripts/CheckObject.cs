using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CheckObject : MonoBehaviour {
	
	public GameObject prefabLabel;
	public GameObject prefabInput;
	public RectTransform ParentPanelData;
	GameObject[] gameObjects;
	GameObject dataPanel;
	Vector2 move = Vector2.zero;
	string[] monsterData = new string[14];
	string[] monsterDataLabel = new string[]{"Name", "Hit Dice", "Speed","Armor" , "Attack", "Weapon","Att.Dis." ,"Str", "Dex","Con","Int" ,"Wis","Cha","Level Adj" };

	bool Scene = false;
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo;
		if (string.Compare (Application.loadedLevelName, "Board") == 0) {

						if ( Input.GetMouseButtonDown (0) && collider.Raycast (ray, out hitInfo, Mathf.Infinity)) {
								monsterData [0] = gameObject.GetComponent<MonsterData> ().Name;
								monsterData [1] = gameObject.GetComponent<MonsterData> ().Hit_dice;
								monsterData [2] = gameObject.GetComponent<MonsterData> ().Speed;
								monsterData [3] = gameObject.GetComponent<MonsterData> ().Armor;
								monsterData [4] = gameObject.GetComponent<MonsterData> ().Attack;
								monsterData [5] = gameObject.GetComponent<MonsterData> ().Weapon;
								monsterData [6] = gameObject.GetComponent<MonsterData> ().Att_Dis;
								monsterData [7] = gameObject.GetComponent<MonsterData> ().Str;
								monsterData [8] = gameObject.GetComponent<MonsterData> ().Dex;
								monsterData [9] = gameObject.GetComponent<MonsterData> ().Con;
								monsterData [10] = gameObject.GetComponent<MonsterData> ().Int;
								monsterData [11] = gameObject.GetComponent<MonsterData> ().Wis;
								monsterData [12] = gameObject.GetComponent<MonsterData> ().Cha;
								monsterData [13] = gameObject.GetComponent<MonsterData> ().Level_Adj;
								ButtonClicked ();
						}
				}

	}

	public void ButtonClicked(){
		gameObjects = GameObject.FindGameObjectsWithTag ("InputData");
		deleteGameObjects ();
		gameObjects = GameObject.FindGameObjectsWithTag ("LabelData");
		deleteGameObjects ();
//		dataPanel = GameObject.FindGameObjectsWithTag ("dataPanel") as GameObject;
		Canvas canvas = FindObjectOfType (typeof(Canvas)) as Canvas;
		RectTransform rectTransform = FindObjectOfType(typeof(RectTransform)) as RectTransform;
		move = rectTransform.transform.position;
		move.x = Screen.width * 0.875f;
		move.y = Screen.height * 0.95f;
		for(int j = 0; j < 13; j++){
			GameObject goLabel = (GameObject)Instantiate(prefabLabel);
			goLabel.transform.parent = canvas.transform;
			goLabel.transform.parent = rectTransform.transform;
			goLabel.transform.position = move;
			goLabel.transform.localScale = new Vector3(1, 1, 1);
			goLabel.transform.position = new Vector3(goLabel.transform.position.x,goLabel.transform.position.y-(30*(j)),goLabel.transform.position.z);
			goLabel.GetComponentInChildren<Text>().text = monsterDataLabel[j];
			GameObject goInput = (GameObject)Instantiate(prefabInput);
			goInput.transform.parent = canvas.transform;
			goInput.transform.parent = rectTransform.transform;
			goInput.transform.position = move;
			goInput.transform.localScale = new Vector3(1, 1, 1);
			goInput.transform.position = new Vector3(goLabel.transform.position.x+100,goLabel.transform.position.y-(10*(j)),goLabel.transform.position.z);
			goInput.GetComponentInChildren<Text>().text = monsterData[j];
		}
	}
	void deleteGameObjects(){
		for(var i = 0 ; i < gameObjects.Length ; i ++)
			Destroy(gameObjects[i]);
	}
}