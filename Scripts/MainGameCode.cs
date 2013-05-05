using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GAMESTATE { UNITSETUP, GAMEPLAY, GAMEOVER} ;
public enum TURNPHASE { SELECTUNIT, AVATARACTION, UNITACTION };

public class MainGameCode : MonoBehaviour {
	
	Player player1;
	Player player2;
	
	public Player activePlayer;

	public BattlefieldCode battlefield;
	public GUICode gui;
	
	bool firstPlayerPlacedUnits=false;
	
	static Unit selectedUnit=null;
	static Unit oldSelectedUnit=null;
	static GameObject selectedTile=null;
	
	
	static public GAMESTATE gameState=GAMESTATE.UNITSETUP;
	static public TURNPHASE turnPhase=TURNPHASE.SELECTUNIT;
	
	
	// Use this for initialization
	void Awake() {
		
		
		//temporarily running the initialize here for testing, eventually move it to the proper screen
		Unit.Initialize();  // move to game start
		Card.Initialize(); //move to game start
		
		//Debug.Log("number of cards in list "+Card.cardList.Count);
		
		player1=new Player(PlayerNameTransfer.getPlayerName(1));
		player2=new Player(PlayerNameTransfer.getPlayerName(2));
		
		DecideWhoGoesFirst();
		//gui.DisplayMessage(activePlayer.getName() + " place your units" );
		
		//HighLightTilesForUnitPlacement();
	
	}
	
	void Start() {
		gui.GuiSetup();	
		HighLightTilesForUnitPlacement();
	}	
	
	void HighLightTilesForUnitPlacement() {
		List<GameObject> validTiles = new List<GameObject>();
		
		
		if (activePlayer==player1) validTiles=battlefield.getBottomRow();
		if (activePlayer==player2) validTiles=battlefield.getTopRow();
		

		battlefield.HighlightTiles(validTiles);
		
	}	
	
	
	// Update is called once per frame
	void Update () {
		if (gameState==GAMESTATE.UNITSETUP) {
		//rotate unit when it is selected
			if (selectedUnit!=null) 
				{ 
					selectedUnit.getDisplayObject().transform.Rotate(new Vector3(0,1f,0)); 
					if (selectedUnit!=oldSelectedUnit && oldSelectedUnit!=null) oldSelectedUnit.getDisplayObject().transform.localEulerAngles=new Vector3(0,180,0);
				}
			//place unit if when both a tile and a unit are selected
			if (selectedUnit!=null && selectedTile!=null && selectedTile.GetComponent<TileCode>().getOccupant()==null) {
				if (
					((activePlayer==player1) && (selectedTile.GetComponent<TileCode>().getY()==1)) ||
					((activePlayer==player2) && (selectedTile.GetComponent<TileCode>().getY()==10)) 
					) { 
					gui.PlaceUnit(selectedUnit,selectedTile);
					
					selectedTile=null;
					selectedUnit=null;
					oldSelectedUnit=null;
				}	
			}
		}
		
		if (gameState==GAMESTATE.GAMEPLAY) {
			if (activePlayer.getSquad().Contains(selectedUnit)) {
				Debug.Log("selected " + selectedUnit.getName());
				selectedUnit=null;
			}
			if (selectedUnit!=null) {
				DrawCards();
			}	
			
		}	
	
	}
	
	void DrawCards() {
		
	}	
	
	
	public void MoveDone() {
		//Log.Print(this,"in move done");
		if (gameState==GAMESTATE.UNITSETUP) {
			if (firstPlayerPlacedUnits) {
				gameState=GAMESTATE.GAMEPLAY;
				battlefield.HighlightTiles(new List<GameObject>());
			}			
			if (!(firstPlayerPlacedUnits)) {
				firstPlayerPlacedUnits=true;
				
			}
		}	
		SwitchActivePlayer();
		gui.GuiSetup();
		
	}	
	
	
	void SwitchActivePlayer() {
		//Log.Print(this,"inswitch, current active player is "+activePlayer.getName());
		if (activePlayer.Equals(player1)) { 
			//Log.Print(this,"inswitch active player equals player 1");
			activePlayer=player2; 
		} else if (activePlayer.Equals(player2))  { 
			//Log.Print(this,"inswitch active player equals player 2");
			activePlayer=player1; 
		}
		if (gameState==GAMESTATE.UNITSETUP) {
			HighLightTilesForUnitPlacement();	
		}	
		
		//Log.Print(this,"out of switchswitch, current active player is "+activePlayer.getName());
	}	
	
	void DecideWhoGoesFirst() {
		
		if (Random.Range(1,3)==1) { 
			activePlayer=player1; } 
		else { 
			activePlayer=player2; } 
	}	
	
	public Player getActivePlayer() {
		return activePlayer;	
	}	
	
	public static GameObject CreateModel(string modelToCreate) {
		//Debug.Log(modelToCreate);
		GameObject tempGameObject=(GameObject) Instantiate((GameObject) Resources.Load("Prefabs/"+modelToCreate) as GameObject);
		return tempGameObject;
	}	
	
	public static void setSelectedUnit(Unit inSelectedUnit) 
	{		
		
		if (gameState==GAMESTATE.UNITSETUP && (!(inSelectedUnit.isPlaced()))) {
			if (selectedTile!=null)  selectedTile=null;
			oldSelectedUnit=selectedUnit;
			selectedUnit=inSelectedUnit;
		}
		if (gameState==GAMESTATE.GAMEPLAY) {
			oldSelectedUnit=selectedUnit;
			selectedUnit=inSelectedUnit;			
		}	
			
		//}	
	}	
	
	public static Unit getSelectedUnit() {
			return selectedUnit;
	}	
	
	public static void setSelectedTile(GameObject inTile) {
		selectedTile=inTile;
		//Debug.Log("clicked "+selectedTile.GetComponent<TileCode>().getX()+" "+selectedTile.GetComponent<TileCode>().getY());
	}	
	
}
