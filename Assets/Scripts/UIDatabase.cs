using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIDatabase : MonoBehaviour {
	public HSController controller = new HSController();

	public GameObject prefabButton;
	public RectTransform ParentPanel;
	public GameObject prefabLabel;
	public GameObject prefabInput;
	public InputField prefabSearch;
	public RectTransform ParentPanelData;
	public bool buttonPress = false;
	GameObject[] gameObjects;
	public int  buttonNumber;

	string[] monsterDataLabel = new string[]{"Name", "Hit Dice", "Speed","Armor" , "Attack", "Weapon","Att.Dis." ,"Str", "Dex","Con","Int" ,"Wis","Cha","Level Adj" };

	void OnGUI () {
		if (GUI.Button (new Rect (0, 75, 50, 20), "toolbar")) {
			createButtonSet();
		}
	}

	public void stringchange(string text)
	{
		gameObjects = GameObject.FindGameObjectsWithTag ("databaseButton");
		text = prefabSearch.text;
		if (text != null) {
			text = prefabSearch.text;
			for (int i = 0; i < gameObjects.Length; i++) {
				string buttontext = gameObjects [i].GetComponentInChildren<Text> ().text;
				gameObjects [i].SetActive (false);
				if (string.Compare (buttontext, text) == 0) {
					gameObjects [i].SetActive (true);
				} else if (text == null) {
					Debug.Log("check");
				for (int j =0; j<gameObjects.Length; j++)
					gameObjects [j].SetActive (true);
				} else {
					gameObjects [i].SetActive (false);
				}
			}
		}
	}

	void createButtonSet()
	{
		for (int i = 0; i < controller.monsterName.Length-1; i++)
		{
			GameObject goButton = (GameObject)Instantiate(prefabButton);
			goButton.transform.SetParent(ParentPanel, false);
			goButton.transform.localScale = new Vector3(1, 1, 1);
			goButton.transform.position = new Vector3(goButton.transform.position.x,goButton.transform.position.y-(30*i),goButton.transform.position.z);
			goButton.GetComponentInChildren<Text>().text = controller.monsterName[i];
			Button tempButton = goButton.GetComponent<Button>();
			int tempInt = i;
			tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
			Debug.Log(i);
			if(i==5)
			{

				Debug.Log("building button");
				GameObject goButton1 = (GameObject)Instantiate(prefabButton);
				goButton1.transform.SetParent(ParentPanel, false);
				goButton1.transform.localScale = new Vector3(1, 1, 1);
				goButton1.transform.position = new Vector3(goButton1.transform.position.x,goButton1.transform.position.y-(30*i+1),goButton1.transform.position.z);
				goButton.GetComponentInChildren<Text>().text = "building";

				tempButton = goButton1.GetComponent<Button>();
				tempInt = i+1;
				tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
				Debug.Log(tempInt);
			}
			Debug.Log(tempInt);

		}
	}

	public void ButtonClicked(int buttonNo)
	{
		buttonNumber = buttonNo;
		int l = 0;
		int k = 0;
		gameObjects = GameObject.FindGameObjectsWithTag ("InputData");
		deleteGameObjects ();
		gameObjects = GameObject.FindGameObjectsWithTag ("LabelData");
		deleteGameObjects ();
		for (int i = 0; i < controller.monsterData.Length; i++) {
			//Debug.Log (buttonNo);
			if(string.Compare(controller.monsterName[buttonNo], controller.monsterData[i]) == 0)
			{
				k = i +13;
				for(int j = i; j < k+1; j++)
				{
					if(j<84)
					{
						GameObject goLabel = (GameObject)Instantiate(prefabLabel);

						goLabel.transform.SetParent(ParentPanelData, false);
						goLabel.transform.localScale = new Vector3(1, 1, 1);
						goLabel.transform.position = new Vector3(goLabel.transform.position.x,goLabel.transform.position.y-(30*(l)),goLabel.transform.position.z);
						goLabel.GetComponentInChildren<Text>().text = monsterDataLabel[l];

						GameObject goInput = (GameObject)Instantiate(prefabInput);

						goInput.transform.SetParent(ParentPanelData, false);
						goInput.transform.localScale = new Vector3(1, 1, 1);
						goInput.transform.position = new Vector3(goLabel.transform.position.x+100,goLabel.transform.position.y-(10*(l)),goLabel.transform.position.z);
						goInput.GetComponentInChildren<Text>().text = controller.monsterData[j];
						l++;
						Debug.Log(j);
					}

				}
				buttonPress = true;
				l++;
				if(buttonNo == 6)
				{
					GameObject goLabel1 = (GameObject)Instantiate(prefabLabel);
					
					goLabel1.transform.SetParent(ParentPanelData, false);
					goLabel1.transform.localScale = new Vector3(1, 1, 1);
					goLabel1.transform.position = new Vector3(goLabel1.transform.position.x,goLabel1.transform.position.y-(30*(l)),goLabel1.transform.position.z);
					goLabel1.GetComponentInChildren<Text>().text = "Name: ";
					GameObject goInput1 = (GameObject)Instantiate(prefabInput);
					goInput1.transform.SetParent(ParentPanelData, false);
					goInput1.transform.localScale = new Vector3(1, 1, 1);
					goInput1.transform.position = new Vector3(goLabel1.transform.position.x+95,goLabel1.transform.position.y-(10*(l)),goLabel1.transform.position.z);
					goInput1.GetComponentInChildren<Text>().text = "Market Place";
				}

				return;
			}
		}
	}

	void deleteGameObjects()
	{
		for(var i = 0 ; i < gameObjects.Length ; i ++)
			Destroy(gameObjects[i]);
	}
}