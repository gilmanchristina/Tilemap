using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ClickableTile : MonoBehaviour {

	public int tileX;
	public int tileY;
	public Vector3 gridPosition = Vector3.zero;
	public Vector3 change = Vector3.zero;
	public TileMap map;
	public bool MoveButton = false;

	public void FixedUpdate() {
		if(Input.GetMouseButtonDown(0) && MoveButton == true){
			change = Input.mousePosition;
			gridPosition.y = (change.y)/48f;
			gridPosition.x = (change.x-320)/48f;
			if(gridPosition.x > 0 && gridPosition.x < 15 ){
				if(gridPosition.y > 0 && gridPosition.y < 15 ){
					tileX = (int)gridPosition.x;
					tileY = (int)gridPosition.y;
					map.GeneratePathTo (tileX, tileY);
				}
			}				
		}
	}
}
