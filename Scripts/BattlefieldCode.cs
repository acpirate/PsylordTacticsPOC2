using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattlefieldCode : MonoBehaviour {
	
	List<Tile> tiles = new List<Tile>();
	
	static int displayTileOffset=10;
	static int battlefieldSize=10;
	static int battlefieldPositionOffset=-55;
	
	public GameObject tileContainer;
	

	// Use this for initialization
	void Start () {
		
		
		for (int xCounter=1;xCounter<battlefieldSize+1;xCounter++) {
			for (int yCounter=1;yCounter<battlefieldSize+1;yCounter++) {
				tiles.Add(new Tile(xCounter,yCounter));	
			}	
		}	
		
		foreach (Tile tile in tiles) {
			GameObject tempTileObject=(GameObject) Instantiate(tile.getPrefab());
			//sets the parent of the tile to the tilecontainer
			
			tile.setDisplayObject(tempTileObject);
			tile.getDisplayObject().transform.parent=tileContainer.transform;
			
			tile.getDisplayObject().transform.localPosition=new Vector3(displayTileOffset * tile.getX()+battlefieldPositionOffset,.6f,displayTileOffset*(int) tile.getY()+battlefieldPositionOffset);
			tile.setVisible(false);
			//tile.getDisplayObject().layer=LayerMask.NameToLayer("battlefield");
			//Debug.Log(tile.getX());
		}	
		
		List<Tile> highlightTileList = new List<Tile>();
		
		foreach (Tile tile in tiles) {
			if (tile.getY()==1) highlightTileList.Add(tile);	
		}	
		
		HighlightTiles(highlightTileList);
	
	}
	
	void HighlightTiles(List<Tile> tilesToHighlight) {
		
		foreach(Tile tile in tilesToHighlight) {
			tile.setVisible(true);	
		}	
		
	}	
	
	// Update is called once per frame
	void Update () {
	
	}
}
