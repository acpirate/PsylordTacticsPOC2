using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GUIMODE { UNITPLACEMENT, PLAYERTURN, OTHERPLAYERTURN, GAMEOVER };

public class Battlefield3DGUICode : MonoBehaviour {
	
	static GUIMODE guiMode=GUIMODE.UNITPLACEMENT;
	
	float screenHeight;
	float screenWidth;
	
	string over="0";
	
	public GUIStyle uiStyle;
	public GUIStyle uiSelectedStyle;
	
	int selectedItem=0;
	
	public GameObject game;
	
	// Use this for initialization
/*	void Start () {
		
		screenHeight=Screen.height;
		screenWidth=Screen.width;
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		
		if (guiMode==GUIMODE.UNITPLACEMENT) {
			
			GUI.Label(new Rect(screenWidth*.5f-100f,10f,400f,50f),"Left click units to select, left click map after unit is selected to place\nValid spaces are highlighted in darkblue\nRight click+drag to move map");
			
			List<Unit> displayUnits=new List<Unit>();
			
			displayUnits=game.GetComponentInChildren<BattleFieldInitializeCode>().player1.getSquad();
				
			foreach (Unit unit in displayUnits) {
				GenerateUnitPlacementButtons(displayUnits.IndexOf(unit)+1);	
			}	
	
			
			over=GUI.tooltip;
			int rotatingUnit;
			
			int.TryParse(over,out rotatingUnit);
			
			BattleFieldInitializeCode.setRotatingUnit(rotatingUnit);
			
		}	
	}
	
	void GenerateUnitPlacementButtons(int buttonPosition) {
		float buttonVerticalSpacing=120f;
		GUIStyle appliedStyle = uiStyle;
		
		
		if (selectedItem==buttonPosition) {
			appliedStyle=uiSelectedStyle;		
		}
		
		
		if (GUI.Button(new Rect(10f,10f+buttonVerticalSpacing*(buttonPosition-1),100,100),new GUIContent("", buttonPosition.ToString()),appliedStyle))  {
			int selectionValue=buttonPosition;
			if (selectedItem==buttonPosition) selectionValue=0;
			
			BattleFieldInitializeCode.setSelectedUnit(selectionValue);
			selectedItem=selectionValue;			
		}
		
	}	*/
}
