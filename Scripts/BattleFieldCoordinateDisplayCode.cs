using UnityEngine;
using System.Collections;

public class BattleFieldCoordinateDisplayCode : MonoBehaviour {
	
	int battlefieldXSize=10;
	int battlefieldYSize=10;
	
	int gridInterval=10;
	int gridXOffset=55;
	int gridYOffset=55;
	
	public GameObject gridCoordinate;
	
	
	// Use this for initialization
	void Start () {
		for(int xCounter=battlefieldXSize;xCounter>0;xCounter--) {
			for (int yCounter=battlefieldYSize;yCounter>0;yCounter--) {
				generateCoordinateDisplay(xCounter,yCounter);		
			}	
			
		}	
		
	
	}
	
	void generateCoordinateDisplay(int x,int y) {
		GameObject tempCoord=(GameObject) Instantiate(gridCoordinate);
		
		tempCoord.transform.parent=transform;
		
		tempCoord.transform.position=new Vector3(tempCoord.transform.position.x+x*gridInterval-gridXOffset,tempCoord.transform.position.y,tempCoord.transform.position.z+y*gridInterval-gridYOffset);
		
		tempCoord.transform.GetComponent<TextMesh>().text=x.ToString() + "," + y.ToString();
	}	
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
