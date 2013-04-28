using UnityEngine;
using System.Collections;

public class Tile {
	
	int xCoordinate;
	int yCoordinate;

	GameObject displayObject;
	
	Unit occupant=null;
	
	static GameObject tilePrefab=null;

	
	public Tile(int inX, int inY) {
		if (tilePrefab==null) tilePrefab=(GameObject) Resources.Load("Prefabs/Tile") as GameObject; 
		
		xCoordinate=inX;
		yCoordinate=inY;
		
	}
	
	public void setOcupant(Unit unitToAdd) {
		occupant=unitToAdd;
		
	}	
	
	public void setDisplayObject(GameObject inDisplayObject) {
		displayObject=inDisplayObject;	
	}	
	
	public GameObject getDisplayObject() {
		return displayObject;	
	}	
	
	public Unit getOccupant() {
		return occupant;
	}	
	
	public GameObject getPrefab() {
		return tilePrefab;	
	}	
	
	public int getX() {
		return xCoordinate;	
	}	
	
	public int getY() {
		return yCoordinate;	
	}
	
	public void setVisible(bool visibility) {
		displayObject.transform.GetComponent<MeshRenderer>().enabled=visibility;	
	}	
	
	
}
