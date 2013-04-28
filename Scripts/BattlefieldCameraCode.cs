using UnityEngine;
using System.Collections;

public class BattlefieldCameraCode : MonoBehaviour {

	bool cameraLookControl=false;
	
	public float  cameraZoomSpeed;
	public float  cameraMoveSpeed;
	public float  cameraInitialHeight;
	public float  cameraInitialHorizontalOffset;
	
	
	
	
	float cameraHeight;
	public GameObject battlefield;
	
	
	// Use this for initialization
	void Start () {
		transform.position=new Vector3(battlefield.transform.position.x-cameraInitialHorizontalOffset ,
											cameraInitialHeight,
											battlefield.transform.position.z);
											
											
		Log.Print(this,transform.rotation.ToString());
		transform.LookAt(battlefield.transform.position);
		Log.Print(this,transform.rotation.ToString());
		
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1)) {
			//Log.Print(this,"camera control enabled");
			cameraLookControl=true;
		}	
		if (Input.GetMouseButtonUp(1)) {
			//Log.Print(this,"camera control disabled");
			cameraLookControl=false;
		}
		
		if (cameraLookControl) ControlCameraLook();
		
		if (Input.GetKey(KeyCode.W)) CameraForward();
	
	}
	
	void ControlCameraLook() {
		
		
	}	
	
	void CameraForward() {
		transform.Translate(Vector3.forward*Time.deltaTime*cameraMoveSpeed);

		
	}
	
	void CameraBackward() {
	}	
	
	void CameraStrafeRight() {
		
	}
	
	void CameraStrafeLeft() {
		
	}
	
	void CameraZoomIn() {
		
	}
	
	void CameraZoomOut() {
		
	}	
	
}
