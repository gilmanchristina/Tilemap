using UnityEngine;
using System.Collections;

public class MonsterCreater : MonoBehaviour {

	public GameObject Monster;
	public GameObject Building;
	Vector2 gridPosition = Vector2.zero;
	Vector2 zero = Vector2.up;
	Transform position;
	Grid grid = new Grid();
	float changex;
	float changey;

	public UIDatabase _uidatabase;
	public HSController hscontroller;

	int number = 0;
	void Start(){
	}
	void Update()
	{

	}
	void  FixedUpdate(){
		if(Input.GetMouseButtonDown(0) && _uidatabase.buttonPress == true){
			gridPosition = Input.mousePosition;
			Vector3 aligned = new Vector3(Mathf.Floor(gridPosition.x/grid.width)*grid.width + grid.width/2.0f, Mathf.Floor(gridPosition.y/grid.height) *grid.height + grid.height/2.0f, 0.0f);
			changey =  Mathf.RoundToInt(gridPosition.y);
			changex = Mathf.RoundToInt(gridPosition.x);
			aligned.y = (changey)/48f;
			aligned.x = (changex-320)/48f;
			gridPosition.x = (int)Mathf.RoundToInt(aligned.x) + 1f;
			gridPosition.y = (int)Mathf.RoundToInt(aligned.y);
			if(gridPosition.x > 0 && gridPosition.x < 15 )
			{
				if(gridPosition.y > 0 && gridPosition.y < 15 )
				{
					number =_uidatabase.buttonNumber;
					if(number < 6)
					{
						addDataToBlock(number, hscontroller.monsterData);
						Instantiate (Monster, gridPosition, Quaternion.identity);
					}
					else
					{
						Instantiate (Building, gridPosition, Quaternion.identity);
					}
				}
			}
			_uidatabase.buttonPress = false;
		}
	}

	void addDataToBlock(int Number, string[] monsterData){
		for (int i = 0; i < hscontroller.monsterData.Length-1; i++) {
			if (string.Compare (hscontroller.monsterName [Number], monsterData [i]) == 0) {
				Monster.GetComponent<MonsterData>().Name = monsterData [i];
				Monster.GetComponent<MonsterData>().Hit_dice = monsterData[i+1];
				Monster.GetComponent<MonsterData>().Speed = monsterData[i+2];
				Monster.GetComponent<MonsterData>().Armor = monsterData[i+3];
				Monster.GetComponent<MonsterData>().Attack = monsterData[i+4];
				Monster.GetComponent<MonsterData>().Weapon = monsterData[i+5];
				Monster.GetComponent<MonsterData>().Att_Dis = monsterData[i+6];
				Monster.GetComponent<MonsterData>().Str = monsterData[i+7];
				Monster.GetComponent<MonsterData>().Dex = monsterData[i+8];
				Monster.GetComponent<MonsterData>().Con = monsterData[i+9];
				Monster.GetComponent<MonsterData>().Int = monsterData[i+10];
				Monster.GetComponent<MonsterData>().Wis = monsterData[i+11];
				Monster.GetComponent<MonsterData>().Cha = monsterData[i+12];
				Monster.GetComponent<MonsterData>().Level_Adj = hscontroller.monsterData[i+13];
			}
		}
	}
}