using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

public class Save : MonoBehaviour {
	/// <summary>
	/// The objects.
	/// </summary>
	public GameObject[] Objects;
	public string SaveString;
	public GameObject[] Building;
	/// <summary>
	/// The objects loaded.
	/// </summary>
	public string LoadString;
	
	/// <summary>
	/// GameObjects
	/// </summary>
	public GameObject[] Objects_;
	public GameObject[] Building_;
	public string savename;
	
	void Start(){
		//LoadGame(savename);
	}
	
//	void Update () {
//		if(Input.GetKeyDown(KeyCode.F5))
//		{
//			Objects = GameObject.FindGameObjectsWithTag("Savable");
//			SaveGame(name);
//		}
//	} 
	
	public void SaveGame(string savename){
		Objects = GameObject.FindGameObjectsWithTag("Savable");
		SaveString = "";
		for(int i = 0; i < Objects.Length; i++)
		{
			SaveString += 
				Objects[i].name 
					+ ","+ 
					Objects[i].transform.position.x + "|" + Objects[i].transform.position.y + "|" +Objects[i].transform.position.z + "|"
					+ ","+ 
					Objects[i].transform.rotation.x + "|" + Objects[i].transform.rotation.y + "|" +Objects[i].transform.rotation.z + "|"
					+ ";";
		}
		
		FileOperations.WriteToFile(savename + ".txt", SaveString);
	}
	
	public void LoadGame(string savename)
	{	
		LoadString = FileOperations.ReadFile(savename + ".txt");
		string[] ObjectsLoaded = LoadString.Split(';');


		foreach(string record in ObjectsLoaded)
		{

				string[] recordSelected = record.Split(',');

				string naz, poz1, rot1;
				string[] poz, rot;
				
				Vector3 pozycja;
				Quaternion rotacja;

				naz = recordSelected[0].ToString();
				//Debug.Log("Loaded: "+naz);
				
				poz1 = recordSelected[1].ToString();
				//Debug.Log("Loaded: "+poz1);
				
				rot1 = recordSelected[2].ToString();
				//Debug.Log("Loaded: "+rot1);
				
				poz = poz1.Split('|');
				
				rot = rot1.Split('|');
				
				pozycja.x = Convert.ToSingle(poz[0]);
				pozycja.y = Convert.ToSingle(poz[1]);
				pozycja.z = Convert.ToSingle(poz[2]);
				
				rotacja.x = Convert.ToSingle(rot[0]);
				rotacja.y = Convert.ToSingle(rot[1]);
				rotacja.z = Convert.ToSingle(rot[2]);
				rotacja.w = 1;
				
				if(naz == "Monster" || naz == "Monster(Clone)")
				{
					Instantiate(Objects_[0], pozycja, rotacja);
				}
				if(naz == "Building" || naz == "Building(Clone)")
				{
					Instantiate(Objects_[1], pozycja, rotacja);
				}	



		}
	}
}
