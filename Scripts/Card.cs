using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public enum CARDEFFECTTYPE { MOVE, ATTACK};
public enum CARDTYPE { ACTION, ENERGY, POWER};

public class Card {
	
	public static List<Card> cardList = new List<Card>();
	
	string name;
	string number;
	string textureName;
	CARDTYPE type;
	List<CardEffect> effects = new List<CardEffect>();
	int deckLimit;
	bool endTurn = false;
	bool foundationCard = false;
	
	//constructors and helper
	
	public Card(string inName, string inNumber, int inDeckLimit, string inTextureName, bool inEndTurn, bool inFoundationCard, string inCardType) {
		
		name=inName;
		number=inNumber;
		deckLimit=inDeckLimit;
		textureName=inTextureName;
		endTurn=inEndTurn;
		foundationCard=inFoundationCard;
		
		switch (inCardType) {
			
			case "Action" : {
				type=CARDTYPE.ACTION;
				break;
			}
			case "Energy" : {
				type=CARDTYPE.ENERGY;
				break;
			}
			case "Power" : {
				type=CARDTYPE.POWER;
				break;
			}			
		}			
		
	}	
	
	public void addEffect(string inType) {	
		effects.Add(new CardEffect(inType));
	}	
	
	public static void Initialize() {
		
		if (cardList.Count==0) {
			
			XmlDocument cardData = new XmlDocument();
			cardData.LoadXml(Resources.Load("CardList").ToString());
			
			foreach (XmlNode cardNode in cardData.DocumentElement.ChildNodes) {
				//card name
				string tempName=XMLHandler.ExtractXMLString(cardNode,"Name");	
				//card number
				string tempNumber=XMLHandler.ExtractXMLString(cardNode,"Number");
				//deck limit
				int tempDeckLimit;
				int.TryParse(XMLHandler.ExtractXMLString(cardNode,"DeckLimit"),out tempDeckLimit);
				//card type
				string tempType=XMLHandler.ExtractXMLString(cardNode,"Type");
				//end turn boolean
				string endTurnString=XMLHandler.ExtractXMLString(cardNode,"EndTurn");
				bool tempEndTurn = false;
				if (endTurnString=="true") tempEndTurn=true;  
				//texture
				string tempTexture=XMLHandler.ExtractXMLString(cardNode,"Texture");
				//foundationcard
				bool tempFoundationCard=false;
				string foundationCardString=cardNode.Attributes["foundation"].Value;
				if (foundationCardString=="true") tempFoundationCard=true;
				
				//construct card		
				cardList.Add(new Card(tempName,tempNumber,tempDeckLimit,tempTexture,tempEndTurn,tempFoundationCard,tempType));
				// add effects to the card
				foreach(XmlNode effectNode in cardNode.SelectNodes("Effect")) {
				
					/*string moveTempName=attackNode.Attributes["name"].Value;
					string moveTempType=attackNode.Attributes["type"].Value;
					int moveTempRange;
					int.TryParse(attackNode.Attributes["range"].Value, out moveTempRange);*/

					string tempEffectType=effectNode.Value;
					
					cardList[cardList.Count-1].addEffect(tempEffectType);
				}
				
				
			}	
			
		}	
		
		
	}	
	
	public static Card getCard(string cardNumberToGet) {
		
		Card returnCard=null;
		
		foreach (Card cardIterator in cardList) {
			//Debug.Log(unitIterator.getName());
			if (cardIterator.getNumber()==cardNumberToGet) returnCard=cardIterator;	
		}	
		
			
		
		if (returnCard==null) {
			Debug.Log("(Card class) unable to find requested card "+cardNumberToGet);	
		}	
		
		return returnCard;
		
	}
	
	public string getNumber() {
		return number;	
	}	
	
}

public class CardEffect {
	
	CARDEFFECTTYPE effect;
	
	public CardEffect(string inCardEffectType) {
	
		switch (inCardEffectType) {
			
			case "Attack" : {
				effect=CARDEFFECTTYPE.ATTACK;
				break;
			}

			case "Move" : {
				effect=CARDEFFECTTYPE.MOVE;
				break;
			}			
		}	
	}	
	
}	