using UnityEngine;
using System.Collections;

public class SetUpCode : MonoBehaviour {
	
	string player1Name="";
	string player2Name="";
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		//play button doesnt work if player names are blank
		if(player1Name=="" || player2Name=="") GUI.enabled=false;
		
		if (GUI.Button (new Rect (Screen.width*.5f-75,Screen.height*.8f-50,150,100), "Play")) {
			PlayerNameTransfer.setPlayer1Name(player1Name);
			PlayerNameTransfer.setPlayer2Name(player2Name);
			Application.LoadLevel("battle");
		}	
		
		GUI.enabled=true;
		
		
		if (GUI.Button (new Rect (Screen.width*.5f-250,Screen.height*.8f-50,150,100), "Back")) {
			Application.LoadLevel("menu");
		}	
		
		GUI.Label(new Rect (10,120,100,20),"Enter Player 1 Name");
		
		player1Name = GUI.TextField (new Rect (10, 160, 100, 30), player1Name);

		GUI.Label(new Rect (10,220,100,20),"Enter Player 2 Name");
		
		player2Name = GUI.TextField (new Rect (10, 260, 100, 30), player2Name);		
		
	}	
}
