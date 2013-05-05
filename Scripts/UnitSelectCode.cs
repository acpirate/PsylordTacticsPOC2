using UnityEngine;
using System.Collections;

public class UnitSelectCode : MonoBehaviour {
	
	Unit myUnit;
	
	void Awake() {
		
	}	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
			MainGameCode.setSelectedUnit(myUnit);
	}	
	
	public void setUnit(Unit inUnit) {
		myUnit=inUnit;	
	}	

}
