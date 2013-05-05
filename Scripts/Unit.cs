using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class Unit {
	
	static List<Unit> unitList = new List<Unit>();
	
	string name;
	string number;
	string prefabName;
	float offset;
	
	List<Move> moves = new List<Move>();
	List<Attack> attacks = new List<Attack>();
	
	int maxHealth;
	
	int currentHealth;
	GameObject displayObject=null;
	
	
	GameObject unitLocation=null;
	bool placed=false;

	//instantiation methods 
	
	public Unit(string inName, string inNumber, int inHealth, string inPrefabName, float inOffset) {
		
		name=inName;
		number=inNumber;
		maxHealth=inHealth;
		prefabName=inPrefabName;
		offset=inOffset;
		
	}	
	
	public void addMove(string inName, string inType, int inRange) {	
		moves.Add(new Move(inName,inType, inRange));
	}	
	
	public void addAttack(string inName, string inType, int inRange, int inDamage, int inAccuracy) {
		attacks.Add(new Attack(inName, inType, inRange, inDamage, inAccuracy));
	}
	
	//initialize is only run once when the game is first started
	
	public static void Initialize() {
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
	}
	
	//access methods
	
	public string getName() {
		return name;	
	}	
	
	public string getNumber() {
		return number;	
	}		
	
	public string getPrefab() {
		return prefabName;	
	}	
	
	
	public float getOffset() {
		return offset;	
	}	
	
	public void setDisplayObject(GameObject inDisplayObject) {
		//Debug.Log("set displayobject display object name" + inDisplayObject.name);
		displayObject=inDisplayObject;
		displayObject.GetComponent<UnitSelectCode>().setUnit(this);
		//Debug.Log("display object name" + displayObject.name);
		
	}	
	
	public GameObject getDisplayObject() {
		return displayObject;
		
	}	
	
	public GameObject getUnitLocation() {
		return unitLocation;
	}	
	
	public bool isPlaced() {
		return placed;	
	}	
	
	public void PlaceUnit(GameObject placementTile) {
	
		unitLocation=placementTile;
		placed=true;
	}	
	
	//access methods for unitlist
	
	public static Unit GetUnit(string unitNumberToGet) {
		
		Unit returnUnit=null;
		
		foreach (Unit unitIterator in unitList) {
			//Debug.Log(unitIterator.getName());
			if (unitIterator.getNumber()==unitNumberToGet) returnUnit=unitIterator;	
		}	
		
			//Configurations.Find(item => item.Name == "myConfig");
		
		if (returnUnit==null) {
			Debug.Log("(Unit class) unable to find requested unit "+unitNumberToGet);	
		}	
		
		return returnUnit;
		
	}	
	
	
	
	
}


// Move
public class Move {
	string name;
	string type;
	int range;
	
	public Move(string inName, string inType, int inRange) {
		name=inName;
		type=inType;
		range=inRange;
	}	
	
}
// Attack
public class Attack {
	string name;
	string type;
	int range;
	int damage;
	int accuracy;
	
	
	public Attack(string inName, string inType, int inRange, int inDamage, int inAccuracy) {
		name=inName;
		type=inType;
		range=inRange;
		damage=inDamage;
		accuracy=inAccuracy;
	}	
	
}	
