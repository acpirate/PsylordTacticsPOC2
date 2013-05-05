using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player {

	List<Unit> squad = new List<Unit>();
	List<Card> currentDeck = new List<Card>();
	List<Card> discardPile = new List<Card>();
	List<Card> hand = new List<Card>();
	string name;
	//temporary to use different units, units will be taken from player profile in real game
	static int squadMakeup=1;
	
	public Player(string inName) {
		FillSquad();
		FillDeck();
		MakeUnitModels();
		setName(inName);
	}	
	
	
	void FillDeck() {
		//action cards
		for (int counter=1;counter<21;counter++) {
			currentDeck.Add(Card.getCard("A0001CD"));	
		}	
		//move cards
		for (int counter=1;counter<21;counter++) {
			currentDeck.Add(Card.getCard("A0002CD"));	
		}
		//Debug.Log(currentDeck.Count);
			
	}	
	
	void FillSquad() {
		if (squadMakeup==1) {
		squad.Add(Unit.GetUnit("A0001U"));
		squad.Add(Unit.GetUnit("A0002U"));
		squad.Add(Unit.GetUnit("A0003U"));
		squad.Add(Unit.GetUnit("A0004U"));
		}
		if (squadMakeup==2) {
		squad.Add(Unit.GetUnit("A0005U"));
		squad.Add(Unit.GetUnit("A0006U"));
		squad.Add(Unit.GetUnit("A0007U"));
		squad.Add(Unit.GetUnit("A0008U"));			
		}	
		squadMakeup=2;
		
		
	}	
	
	void DrawCards(Unit drawUnit) {
	
	}	
	
	void MakeUnitModels() {
		foreach(Unit unit in squad) {
			unit.setDisplayObject(MainGameCode.CreateModel(unit.getPrefab()));
			unit.getDisplayObject().SetActive(false);
		}	
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
