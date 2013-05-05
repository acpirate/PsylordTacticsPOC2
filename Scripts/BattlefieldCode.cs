using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattlefieldCode : MonoBehaviour {
	
	List<GameObject> tiles = new List<GameObject>();
	
	public static int displayTileOffset=10;
	public static int battlefieldSize=10;
	public static int battlefieldPositionOffset=-55;
	
	public GameObject tileContainer;
	
	public GameObject tilePrefab;
	

	// Use this for initialization
	void Awake () {
		GameObject tempTileObject;
		
		for (int xCounter=1;xCounter<battlefieldSize+1;xCounter++) {
			for (int yCounter=1;yCounter<battlefieldSize+1;yCounter++) {
				//Debug.Log(xCounter + " " +yCounter);
				tempTileObject=(GameObject) Instantiate(tilePrefab);
				tempTileObject.transform.parent=tileContainer.transform;
				tempTileObject.GetComponent<TileCode>().setCoordinates(xCounter,yCounter);
			
				tempTileObject.transform.localPosition=new Vector3(displayTileOffset *(int) tempTileObject.GetComponent<TileCode>().getX()+battlefieldPositionOffset,.6f,displayTileOffset*(int) tempTileObject.GetComponent<TileCode>().getY()+battlefieldPositionOffset);
				tempTileObject.GetComponent<TileCode>().setVisible(false);	
				
				tiles.Add(tempTileObject);
			}	
		}	
		
		/*foreach (Tile tile in tiles) {
			GameObject tempTileObject=(GameObject) Instantiate(tile.getPrefab());
			tempTileObject.transform.parent=tileContainer.transform;
			
			
			tempTileObject.transform.localPosition=new Vector3(displayTileOffset * tile.getX()+battlefieldPositionOffset,.6f,displayTileOffset*(int) tile.getY()+battlefieldPositionOffset);
			tempTileObject.GetComponent<TileCode>().setVisible(false);

		}*/	
		
		//List<Tile> highlightTileList = new List<Tile>();
		
	/*	foreach (Tile tile in tiles) {
			if (tile.getY()==1) highlightTileList.Add(tile);	
		}	*/
		
	//	HighlightTiles(highlightTileList);
	
	}
	
	public List<GameObject> getBottomRow() { 
		//Debug.Log("in get bottom row");
		List<GameObject> highlightTileList = new List<GameObject>();
		
		foreach (GameObject tile in tiles) {
			if (tile.GetComponent<TileCode>().getY()==1) highlightTileList.Add(tile);	
		}
		
		return highlightTileList;
		
	}	
	
	public List<GameObject> getTopRow() { 
		//Debug.Log("in get top row");
		List<GameObject> highlightTileList = new List<GameObject>();
		
		foreach (GameObject tile in tiles) {
			if (tile.GetComponent<TileCode>().getY()==10) highlightTileList.Add(tile);	
		}
		
		//Debug.Log(highlightTileList.Count);
		
		return highlightTileList;
	}	
		
	
	public void HighlightTiles(List<GameObject> tilesToHighlight) {
		//Debug.Log("in highlight tiles");
		foreach(GameObject tile in tiles) {
			tile.GetComponent<TileCode>().setVisible(false);	
		}	
		
		
		foreach(GameObject tile in tilesToHighlight) {
			tile.GetComponent<TileCode>().setVisible(true);	
		}	
		
	}	
	
	// Update is called once per frame
	void Update () {
	
	}
	
}
