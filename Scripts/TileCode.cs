using UnityEngine;
using System.Collections;

public class TileCode : MonoBehaviour {
	
	int xCoordinate;
	int yCoordinate;


	
	Unit occupant=null;


	
	/*public Tile(int inX, int inY) {
		if (tilePrefab==null) tilePrefab=(GameObject) Resources.Load("Prefabs/Tile") as GameObject; 
		
		xCoordinate=inX;
		yCoordinate=inY;
		
	}*/
	
	public void setCoordinates(int inX, int inY) {
		xCoordinate=inX;
		yCoordinate=inY;
	}	
	
	
	public void setOccupant(Unit unitToAdd) {
		occupant=unitToAdd;
		
	}	
	
	public void OnMouseDown() {
		MainGameCode.setSelectedTile(this.gameObject);
	}	
	
	public Unit getOccupant() {
		return occupant;
	}	
	
	
	public int getX() {
		return xCoordinate;	
	}	
	
	public int getY() {
		return yCoordinate;	
	}
	
	public void setVisible(bool visibility) {
		transform.GetComponent<MeshRenderer>().enabled=visibility;	
	}	
	
	
}
