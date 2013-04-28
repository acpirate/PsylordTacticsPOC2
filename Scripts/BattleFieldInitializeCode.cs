using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BattleFieldInitializeCode : MonoBehaviour {
	
	public Transform GUICamera;
	
	//public Player player1=new Player("player1");
	//public Player player2=new Player("player2");
	
	List<Unit> unitsForDisplay = new List<Unit>();
	
	static int rotatingUnit=0;
	static int selectedUnit=0;
	
	float rotationSpeed = -1f;
	
	
	// Use this for initialization
	void Start () {
		

		//player1.FillSquad();
		//player2.FillSquad();
		
		//unitsForDisplay=player1.getSquad();
		//DisplayUnitsForPlacement();
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
	/*	if (rotatingUnit!=0) {
			DisplayRotate(unitsForDisplay[rotatingUnit-1].getDisplayObject());
		}	
		if (selectedUnit!=0) {
			DisplayRotate(unitsForDisplay[selectedUnit-1].getDisplayObject());
		}*/		

	
	}
	
	/*public static void setRotatingUnit(int inRotatingUnit) {
			rotatingUnit=inRotatingUnit;
	}	
	
	public static void setSelectedUnit(int inSelectedUnit) {
			selectedUnit=inSelectedUnit;	
	}	
	
	void DisplayRotate(GameObject objectToRotate) {
		objectToRotate.transform.RotateAround(new Vector3(0,1,0),rotationSpeed*Time.deltaTime);	
	}	
	
	
	void DisplayUnitsForPlacement() {
		
		float magicUIPlacementNumber=3.9f;
		
		foreach(Unit unitIterator in unitsForDisplay) {
			GameObject tempObject=(GameObject) Instantiate((GameObject) Resources.Load("Prefabs/"+unitIterator.getPrefab()));
			tempObject.transform.parent=GUICamera;
			unitIterator.setDisplayObject(tempObject);
			
			
 			MoveToLayer(tempObject.transform,"3DGUI");			
			
			tempObject.transform.localPosition=new Vector3(-12.5f,
				8+unitIterator.getOffset()-magicUIPlacementNumber*unitsForDisplay.IndexOf(unitIterator),
				5);
			tempObject.transform.localScale=new Vector3(.6f,.6f,.6f);
		}	
		
	}
	
	void MoveToLayer(Transform root, string layerName) {
			root.gameObject.layer = LayerMask.NameToLayer(layerName);
			foreach(Transform child in root) MoveToLayer(child, layerName);
	}*/
	
	
}
