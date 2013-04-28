using UnityEngine;
using System.Collections;

public class PlayerNameTransfer {
	
	static string player1Name="rodney";
	static string player2Name="alex";
	
	public static void setPlayer1Name(string inName) {
		player1Name=inName;	
	}	

	public static void setPlayer2Name(string inName) {
		player2Name=inName;	
	}
	
	public static string getPlayerName(int player) {
		string tempName="ERROR";
		
		if (player==1) tempName=player1Name;
		if (player==2) tempName=player2Name;
		
		return tempName;
		
		
	}	
}
