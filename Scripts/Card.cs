using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public enum CARDEFFECTTYPE { MOVE, ATTACK};
public enum CARDTYPE { ACTION, ENERGY, POWER};

public class Card {
	
	static List<Card> cardList = new List<Card>();
	
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
				string tempTextuer=XMLHandler.ExtractXMLString(cardNode,"Texture");
				
			}	
			
		}	
		
		
	}	
	
/*	public static void Initialize() {
		//Debug.Log("in initialize");
		//Debug.Log(unitList.Count);
		
		if (unitList.Count==0) {
		
			XmlDocument unitData = new XmlDocument();
			unitData.LoadXml(Resources.Load("UnitList").ToString());
			
			//Debug.Log(unitData);
			//iterate over each unit in the xml data
			foreach (XmlNode unitNode in unitData.DocumentElement.ChildNodes) {
					int tempHealth;
					string tempName=XMLHandler.ExtractXMLString(unitNode,"Name");
					string tempNumber=XMLHandler.ExtractXMLString(unitNode,"Number");
					int.TryParse(XMLHandler.ExtractXMLString(unitNode,"Health"),out tempHealth);
					string tempPrefab=XMLHandler.ExtractXMLString(unitNode,"Prefab");
					float tempOffset;
					float.TryParse(XMLHandler.ExtractXMLString(unitNode,"Offset"),out tempOffset);
					//add unit to the unit list
					unitList.Add(new Unit(tempName,tempNumber,tempHealth,tempPrefab, tempOffset));
					//add the attack modes to the unit
					foreach(XmlNode attackNode in unitNode.SelectNodes("Attack")) {
					
						string attackTempName=attackNode.Attributes["name"].Value;
						string attackTempType=attackNode.Attributes["type"].Value;
						int attackTempRange;
						int.TryParse(attackNode.Attributes["range"].Value, out attackTempRange);
						int attackTempDamage;
						int.TryParse(attackNode.Attributes["damage"].Value, out attackTempDamage);
						int attackTempAccuracy;
						int.TryParse(attackNode.Attributes["accuracy"].Value, out attackTempAccuracy);
					
						unitList[unitList.Count-1].addAttack(attackTempName,attackTempType,attackTempRange,attackTempDamage,attackTempAccuracy);
					}
					// add the move modes to the unit
					foreach(XmlNode attackNode in unitNode.SelectNodes("Move")) {
					
						string moveTempName=attackNode.Attributes["name"].Value;
						string moveTempType=attackNode.Attributes["type"].Value;
						int moveTempRange;
						int.TryParse(attackNode.Attributes["range"].Value, out moveTempRange);
	
					
						unitList[unitList.Count-1].addMove(moveTempName,moveTempType,moveTempRange);
					}				
			}
			
		}	
	}*/	
	
	
	
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