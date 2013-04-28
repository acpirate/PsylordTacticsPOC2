using UnityEngine;
using System.Collections;

public class MainGameCode : MonoBehaviour {
	
	Player player1;
	Player player2;
	
	
	public GameObject battlefield;
	
	// Use this for initialization
	void Start () {
		
		//temporarily running the initialize here for testing, eventually move it to the proper screen
		Unit.Initialize();  // move to game start
		Card.Initialize(); //move to game start
		
		player1=new Player(PlayerNameTransfer.getPlayerName(1));
		player2=new Player(PlayerNameTransfer.getPlayerName(2));
		
		Debug.Log(player1.getName() + " " + player2.getName());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
