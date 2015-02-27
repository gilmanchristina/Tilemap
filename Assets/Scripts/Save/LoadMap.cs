using UnityEngine;
using System.Collections;

public class LoadMap : MonoBehaviour {
	public Save savObj;
	public string savename;
	// Use this for initialization
	void Start () {
		savObj.LoadGame (savename);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
