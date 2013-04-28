using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player {

	List<Unit> squad = new List<Unit>();
	List<Card> currentDeck = new List<Card>();
	List<Card> discardPile = new List<Card>();
	List<Card> hand = new List<Card>();
	string name;
	
	
	public Player(string inName) {
		FillSquad();
		setName(inName);
	}	
	
	public void FillSquad() {
	
		squad.Add(Unit.GetUnit("A0001U"));
		squad.Add(Unit.GetUnit("A0002U"));
		squad.Add(Unit.GetUnit("A0003U"));
		squad.Add(Unit.GetUnit("A0004U"));
		
	}	
	
	public void setName(string inName) {
		name=inName;	
	}	
	
	public string getName() {
		return name;
	}	
	
	public List<Unit> getSquad() {
		
		return squad;
		
	}	
	
	public void setCurrentDeck(List<Card> inDeck) {
		currentDeck=inDeck;
	}	
	
	public void setHand(List<Card> inHand) {
		hand=inHand;
	}
	
}
