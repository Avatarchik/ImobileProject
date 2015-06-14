// iPhone gyroscope-controlled camera demo v0.3 8/8/11
// Perry Hoberman <hoberman@bway.net>
// Directions: Attach this script to main camera.
// Note: Unity Remote does not currently support gyroscope. 

using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private bool gyroBool;
	private Gyroscope gyro;
	private Quaternion rotFix;
	public GameObject fpc;
	
	public void Init() {	
		/*
		Transform originalParent = transform.parent; // check if this transform has a parent
		GameObject camParent = new GameObject ("camParent"); // make a new parent
		camParent.transform.position = transform.position; // move the new parent to this transform position
		transform.parent = camParent.transform; // make this transform a child of the new parent
		camParent.transform.parent = originalParent; // make the new parent a child of the original parent
		*/
		gyroBool = Input.gyro.enabled;
		
		if (gyroBool) {
			
			gyro = Input.gyro;
			gyro.enabled = true;
			
			if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
				transform.parent.eulerAngles = new Vector3(90f,90f,0f);
			} else if (Screen.orientation == ScreenOrientation.Portrait) {
				transform.parent.eulerAngles = new Vector3(90f,90f,0f);
			}
			
			if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
				rotFix = new Quaternion(0f,0f,0.7071f,0.7071f);
			} else if (Screen.orientation == ScreenOrientation.Portrait) {
				rotFix = new Quaternion(0f,0f,1f,0f);
			}		
		} 
		else {
			print("NO GYRO");
		}
	}
	public void End() {
		transform.parent.eulerAngles = Vector3.zero;
		gyroBool = false;
	}
	
	void Update () {
		if (gyroBool) {
			Quaternion camRot = gyro.attitude * rotFix;
			transform.localRotation = camRot;
			Vector3 direction = camRot * Vector3.up;
			direction.y = 0;
			//gameObject.Find("print").guiText.text = direction.ToString();
			//fpc.transform.rotation = Quaternion.LookRotation(direction);
		}
	}
}
