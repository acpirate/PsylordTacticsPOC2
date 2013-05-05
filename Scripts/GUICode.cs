using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUICode : MonoBehaviour {
	
	public GUIText messageLine;
	public Camera GUICam;
	public GameObject battlefield;
	
	MainGameCode game = null;

	
	
	// Use this for initialization
	void Awake () {
		game=GameObject.Find("Main").GetComponent<MainGameCode>();
		
	}
	
	void Start() {

	}	
	

	// Update is called once per frame
	void Update () {
		
	}
	
	
	void OnGUI() {
		if (MainGameCode.gameState==GAMESTATE.UNITSETUP) {
			DisplayMessage(game.getActivePlayer().getName() + " place your units");
			bool allPlaced=true;
			foreach (Unit unit in game.activePlayer.getSquad()) {
				if (!(unit.isPlaced())) allPlaced=false;
			}	
			if (allPlaced) {
				if (GUI.Button(new Rect(Screen.width*.1f,Screen.height*.05f,Screen.width*.1f,Screen.height*.1f),"Done")) {
					game.MoveDone();	
				}					
			}	
		}	
		if (MainGameCode.gameState==GAMESTATE.GAMEPLAY) {
			DisplayMessage(game.getActivePlayer().getName() + " select a unit to activate");
			if (GUI.Button(new Rect(Screen.width*.1f,Screen.height*.05f,Screen.width*.1f,Screen.height*.1f),"End Turn")) {
				game.MoveDone();	
			}			
		}	
	}	
	
	public void GuiSetup() {
		if (MainGameCode.gameState==GAMESTATE.UNITSETUP) {
			DisplayMessage(game.getActivePlayer().getName() + " place your units");
			List<Unit> tempSquad=game.getActivePlayer().getSquad();
			//Debug.Log(tempSquad.Count);
			foreach (Unit unit in tempSquad) {
				unit.getDisplayObject().SetActive(true);
				MoveToLayer(unit.getDisplayObject().transform,"3DGUI");
				unit.getDisplayObject().transform.parent=GUICam.transform;
				unit.getDisplayObject().transform.localPosition=new Vector3(0,0,5f);
				float screenPercent=.2f*tempSquad.IndexOf(unit);
				
				
				unit.getDisplayObject().transform.position=GUICam.ViewportToWorldPoint (new Vector3 (.05f,.8f-screenPercent, GUICam.nearClipPlane+5f));
				Vector3 tempPosition = unit.getDisplayObject().transform.position;
				
				tempPosition+=new Vector3(0f,unit.getOffset(),0f);
				unit.getDisplayObject().transform.position=tempPosition;
			}		
		}	
		
		
	}	
	
	public void DisplayMessage(string messageToDisplay) {
		messageLine.text=messageToDisplay;
	}
	
	//recursively move object to layer, used for 3d gui
	void MoveToLayer(Transform root, string layerName) {
			root.gameObject.layer = LayerMask.NameToLayer(layerName);
			foreach(Transform child in root) MoveToLayer(child, layerName);
	}
	
	public void PlaceUnit(Unit unitToPlace, GameObject tileTarget) {
		
		unitToPlace.PlaceUnit(tileTarget);
		unitToPlace.getDisplayObject().transform.parent=battlefield.transform;
		PositionUnitOnBattleField(unitToPlace,tileTarget);
		tileTarget.GetComponent<TileCode>().setOccupant(unitToPlace);
		
		//unitToPlace.getDisplayObject().transform.localPosition=new Vector3(0,0+unitToPlace.getOffset()+5f,0);
		MoveToLayer(unitToPlace.getDisplayObject().transform,"Default");	
		
	}
	
	void PositionUnitOnBattleField(Unit unitToPlace, GameObject tileTarget) {
		
		float xPosition = -.55f + tileTarget.GetComponent<TileCode>().getX()*.1f;
		float yPosition = -.55f + tileTarget.GetComponent<TileCode>().getY()*.1f;
		
		//Debug.Log(tileTarget.GetComponent<TileCode>().getX() + " " + tileTarget.GetComponent<TileCode>().getY()); 
		
		//Debug.Log(xPosition+" "+yPosition);
		
		unitToPlace.getDisplayObject().transform.localPosition=new Vector3(xPosition,3f,yPosition);
		unitToPlace.getDisplayObject().transform.localRotation=Quaternion.identity;
		
	}	
	
	
}
