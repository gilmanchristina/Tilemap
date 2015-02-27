using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterUI : MonoBehaviour {

	public CharacterData Data;
	public GameObject Page1;
	GameObject Page1Clone;
	public GameObject Page2;
	bool page1 = true;
	bool page2 = false;
	public GameObject[] textbox1;
	GameObject[] textbox2;
	void OnGUI()
	{
		if (page1 == true) {
			Setup ();
			if (GUI.Button (new Rect(10, 10, 100, 25), "Next Page")) {
				GetDataPage1 ();
				page1 = false;
				page2 = true;
			}
		} 
		else if (page2 == true) {
			Setup2 ();
			if (GUI.Button (new Rect (10, 10, 100, 25), "Submit")) {
				GetDataPage2();
				Application.LoadLevel(0);
			}
		}
}
	void Setup(){
		if (GameObject.FindGameObjectWithTag ("Canvas1") == false) {
			Page1Clone = Instantiate (Page1, Vector3.zero, Quaternion.identity)as GameObject;
		} else {
			return;
		}
	}
	void Setup2(){
		if (GameObject.FindGameObjectWithTag ("Canvas2") == false) {
			Destroy(Page1Clone);
			Instantiate (Page2, Vector3.zero, Quaternion.identity);
		} else {
			return;
		}
	}

	void GetDataPage1(){

		textbox1 = GameObject.FindGameObjectsWithTag ("Charactersheet1");

		Data.Campaign = textbox1 [0].GetComponent<Text> ().text;
		Data.ExperiencePoints = textbox1 [1].GetComponent<Text> ().text;
		Data.ArmorItem = textbox1 [2].GetComponent<Text> ().text;
		Data.ArmorType = textbox1 [3].GetComponent<Text> ().text;
		Data.ArmorAC = textbox1 [4].GetComponent<Text> ().text;
		Data.ArmorMax = textbox1 [5].GetComponent<Text> ().text;
		Data.ArmorPenaltyCheck = textbox1 [6].GetComponent<Text> ().text;
		Data.ArmorSpellCheck = textbox1 [7].GetComponent<Text> ().text;
		Data.ArmorSpeed = textbox1 [8].GetComponent<Text> ().text;
		Data.ArmorWeight = textbox1 [9].GetComponent<Text> ().text;
		Data.ArmorSpecialProperties = textbox1 [10].GetComponent<Text> ().text;
		Data.ShieldItem = textbox1 [11].GetComponent<Text> ().text;
		Data.ShieldACBonus = textbox1 [12].GetComponent<Text> ().text;
		Data.ShieldWeight = textbox1 [13].GetComponent<Text> ().text;
		Data.ShieldPenaltyCheck = textbox1 [14].GetComponent<Text> ().text;
		Data.ShieldSpellFailure = textbox1 [15].GetComponent<Text> ().text;
		Data.ShieldSpecialProperties = textbox1 [16].GetComponent<Text> ().text;
		Data.ProtectiveItem_1 = textbox1 [17].GetComponent<Text> ().text;
		Data.ProtectiveACBonus_1 = textbox1 [18].GetComponent<Text> ().text;
		Data.ProtectiveWeight_1 = textbox1 [19].GetComponent<Text> ().text;
		Data.ProtectiveSpecialProperties_1 = textbox1 [20].GetComponent<Text> ().text;
		Data.ProtectiveItem_2 = textbox1 [21].GetComponent<Text> ().text;
		Data.ProtectiveACBonus_2 = textbox1 [22].GetComponent<Text> ().text;
		Data.ProtectiveWeight_2 = textbox1 [23].GetComponent<Text> ().text;
		Data.ProtectiveSpecialProperties_2 = textbox1 [24].GetComponent<Text> ().text;
		Data.PossessionsLightLoad = textbox1 [25].GetComponent<Text> ().text;
		Data.PossessionsMediumLoad = textbox1 [26].GetComponent<Text> ().text;
		Data.PossessionsHeavyLoad = textbox1 [27].GetComponent<Text> ().text;
		Data.PossessionsPushorDrag = textbox1 [28].GetComponent<Text> ().text;
		Data.PossessionsLiftoffGround = textbox1 [29].GetComponent<Text> ().text;
		Data.PossessionsLiftoverHead = textbox1 [30].GetComponent<Text> ().text;
		Data.MoneyCP = textbox1 [31].GetComponent<Text> ().text;
		Data.MoneySP = textbox1 [32].GetComponent<Text> ().text;
		Data.MoneyGP = textbox1 [33].GetComponent<Text> ().text;
		Data.MoneyPP = textbox1 [34].GetComponent<Text> ().text;
		Data.Language_1 = textbox1 [35].GetComponent<Text> ().text;
		Data.Language_2 = textbox1 [36].GetComponent<Text> ().text;
		Data.Language_3 = textbox1 [37].GetComponent<Text> ().text;
		Data.Language_4 = textbox1 [38].GetComponent<Text> ().text;
		Data.Language_5 = textbox1 [39].GetComponent<Text> ().text;
		Data.Language_6 = textbox1 [40].GetComponent<Text> ().text;
		Data.Feats_1 = textbox1 [41].GetComponent<Text> ().text;
		Data.Feats_2 = textbox1 [42].GetComponent<Text> ().text;
		Data.Feats_3 = textbox1 [43].GetComponent<Text> ().text;
		Data.Feats_4 = textbox1 [44].GetComponent<Text> ().text;
		Data.Feats_5 = textbox1 [45].GetComponent<Text> ().text;
		Data.Feats_6 = textbox1 [46].GetComponent<Text> ().text;
		Data.Feats_7 = textbox1 [47].GetComponent<Text> ().text;
		Data.Feats_8 = textbox1 [48].GetComponent<Text> ().text;
		Data.Feats_9 = textbox1 [49].GetComponent<Text> ().text;
		Data.Feats_10 = textbox1 [50].GetComponent<Text> ().text;
		Data.Feats_11 = textbox1 [51].GetComponent<Text> ().text;
		Data.Feats_12 = textbox1 [52].GetComponent<Text> ().text;
		Data.SpecialAbility_1 = textbox1 [53].GetComponent<Text> ().text;
		Data.SpecialAbility_2 = textbox1 [54].GetComponent<Text> ().text;
		Data.SpecialAbility_3 = textbox1 [55].GetComponent<Text> ().text;
		Data.SpecialAbility_4 = textbox1 [56].GetComponent<Text> ().text;
		Data.SpecialAbility_5 = textbox1 [57].GetComponent<Text> ().text;
		Data.SpecialAbility_6 = textbox1 [58].GetComponent<Text> ().text;
		Data.SpecialAbility_7 = textbox1 [59].GetComponent<Text> ().text;
		Data.SpecialAbility_8 = textbox1 [60].GetComponent<Text> ().text;
		Data.SpecialAbility_9 = textbox1 [61].GetComponent<Text> ().text;
		Data.SpecialAbility_10 = textbox1 [62].GetComponent<Text> ().text;
		Data.SpecialAbility_11 = textbox1 [63].GetComponent<Text> ().text;
		Data.SpecialAbility_12 = textbox1 [64].GetComponent<Text> ().text;
		Data.SpecialAbility_13 = textbox1 [65].GetComponent<Text> ().text;
		Data.SpecialAbility_14 = textbox1 [66].GetComponent<Text> ().text;
		Data.SpecialAbility_15 = textbox1 [67].GetComponent<Text> ().text;
		Data.SpecialAbility_16 = textbox1 [68].GetComponent<Text> ().text;
		Data.SpecialAbility_17 = textbox1 [69].GetComponent<Text> ().text;
		Data.SpecialAbility_18 = textbox1 [70].GetComponent<Text> ().text;
		Data.SpecialAbility_19 = textbox1 [71].GetComponent<Text> ().text;
		Data.SpecialAbility_20 = textbox1 [72].GetComponent<Text> ().text;
		Data.SpecialAbility_21 = textbox1 [73].GetComponent<Text> ().text;
		Data.SpecialAbility_22 = textbox1 [74].GetComponent<Text> ().text;
		Data.SpecialAbility_23 = textbox1 [75].GetComponent<Text> ().text;
}
	void GetDataPage2(){

		textbox2 = GameObject.FindGameObjectsWithTag ("Charactersheet2");

		Data.Campaign = textbox2 [0].GetComponent<Text>().text;
		Data.ExperiencePoints = textbox2 [1].GetComponent<Text>().text;
		Data.ArmorItem = textbox2 [2].GetComponent<Text>().text;
		Data.ArmorType = textbox2 [3].GetComponent<Text>().text;
		Data.ArmorAC = textbox2 [4].GetComponent<Text>().text;
		Data.ArmorMax = textbox2 [5].GetComponent<Text>().text;
		Data.ArmorPenaltyCheck = textbox2 [6].GetComponent<Text>().text;
		Data.ArmorSpellCheck = textbox2 [7].GetComponent<Text>().text;
		Data.ArmorSpeed = textbox2 [8].GetComponent<Text>().text;
		Data.ArmorWeight = textbox2 [9].GetComponent<Text>().text;
		Data.ArmorSpecialProperties = textbox2 [10].GetComponent<Text>().text;
		Data.ShieldItem = textbox2 [11].GetComponent<Text>().text;
		Data.ShieldACBonus = textbox2 [12].GetComponent<Text>().text;
		Data.ShieldWeight = textbox2 [13].GetComponent<Text>().text;
		Data.ShieldPenaltyCheck = textbox2 [14].GetComponent<Text>().text;
		Data.ShieldSpellFailure = textbox2 [15].GetComponent<Text>().text;
		Data.ShieldSpecialProperties = textbox2 [16].GetComponent<Text>().text;
		Data.ProtectiveItem_1 = textbox2 [17].GetComponent<Text>().text;
		Data.ProtectiveACBonus_1 = textbox2 [18].GetComponent<Text>().text;
		Data.ProtectiveWeight_1 = textbox2 [19].GetComponent<Text>().text;
		Data.ProtectiveSpecialProperties_1 = textbox2 [20].GetComponent<Text>().text;
		Data.ProtectiveItem_2 = textbox2 [21].GetComponent<Text>().text;
		Data.ProtectiveACBonus_2 = textbox2 [22].GetComponent<Text>().text;
		Data.ProtectiveWeight_2 = textbox2 [23].GetComponent<Text>().text;
		Data.ProtectiveSpecialProperties_2 = textbox2 [24].GetComponent<Text>().text;
		Data.PossessionsLightLoad = textbox2 [25].GetComponent<Text>().text;
		Data.PossessionsMediumLoad = textbox2 [26].GetComponent<Text>().text;
		Data.PossessionsHeavyLoad = textbox2 [27].GetComponent<Text>().text;
		Data.PossessionsPushorDrag = textbox2 [28].GetComponent<Text>().text;
		Data.PossessionsLiftoffGround = textbox2 [29].GetComponent<Text>().text;
		Data.PossessionsLiftoverHead = textbox2 [30].GetComponent<Text>().text;
		Data.MoneyCP = textbox2 [31].GetComponent<Text>().text;
		Data.MoneySP = textbox2 [32].GetComponent<Text>().text;
		Data.MoneyGP = textbox2 [33].GetComponent<Text>().text;
		Data.MoneyPP = textbox2 [34].GetComponent<Text>().text;
		Data.Language_1 = textbox2 [35].GetComponent<Text>().text;
		Data.Language_2 = textbox2 [36].GetComponent<Text>().text;
		Data.Language_3 = textbox2 [37].GetComponent<Text>().text;
		Data.Language_4 = textbox2 [38].GetComponent<Text>().text;
		Data.Language_5 = textbox2 [39].GetComponent<Text>().text;
		Data.Language_6 = textbox2 [40].GetComponent<Text>().text;
		Data.Feats_1 = textbox2 [41].GetComponent<Text>().text;
		Data.Feats_2 = textbox2 [42].GetComponent<Text>().text;
		Data.Feats_3 = textbox2 [43].GetComponent<Text>().text;
		Data.Feats_4 = textbox2 [44].GetComponent<Text>().text;
		Data.Feats_5 = textbox2 [45].GetComponent<Text>().text;
		Data.Feats_6 = textbox2 [46].GetComponent<Text>().text;
		Data.Feats_7 = textbox2 [47].GetComponent<Text>().text;
		Data.Feats_8 = textbox2 [48].GetComponent<Text>().text;
		Data.Feats_9 = textbox2 [49].GetComponent<Text>().text;
		Data.Feats_10 = textbox2 [50].GetComponent<Text>().text;
		Data.Feats_11 = textbox2 [51].GetComponent<Text>().text;
		Data.Feats_12 = textbox2 [52].GetComponent<Text>().text;
		Data.SpecialAbility_1 = textbox2 [53].GetComponent<Text>().text;
		Data.SpecialAbility_2 = textbox2 [54].GetComponent<Text>().text;
		Data.SpecialAbility_3 = textbox2 [55].GetComponent<Text>().text;
		Data.SpecialAbility_4 = textbox2 [56].GetComponent<Text>().text;
		Data.SpecialAbility_5 = textbox2 [57].GetComponent<Text>().text;
		Data.SpecialAbility_6 = textbox2 [58].GetComponent<Text>().text;
		Data.SpecialAbility_7 = textbox2 [59].GetComponent<Text>().text;
		Data.SpecialAbility_8 = textbox2 [60].GetComponent<Text>().text;
		Data.SpecialAbility_9 = textbox2 [61].GetComponent<Text>().text;
		Data.SpecialAbility_10 = textbox2 [62].GetComponent<Text>().text;
		Data.SpecialAbility_11 = textbox2 [63].GetComponent<Text>().text;
		Data.SpecialAbility_12 = textbox2 [64].GetComponent<Text>().text;
		Data.SpecialAbility_13 = textbox2 [65].GetComponent<Text>().text;
		Data.SpecialAbility_14 = textbox2 [66].GetComponent<Text>().text;
		Data.SpecialAbility_15 = textbox2 [67].GetComponent<Text>().text;
		Data.SpecialAbility_16 = textbox2 [68].GetComponent<Text>().text;
		Data.SpecialAbility_17 = textbox2 [69].GetComponent<Text>().text;
		Data.SpecialAbility_18 = textbox2 [70].GetComponent<Text>().text;
		Data.SpecialAbility_19 = textbox2 [71].GetComponent<Text>().text;
		Data.SpecialAbility_20 = textbox2 [72].GetComponent<Text>().text;
		Data.SpecialAbility_21 = textbox2 [73].GetComponent<Text>().text;
		Data.SpecialAbility_22 = textbox2 [74].GetComponent<Text>().text;
		Data.SpecialAbility_23 = textbox2 [75].GetComponent<Text>().text;
	}
}
