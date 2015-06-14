using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MovePanning : MonoBehaviour {
	public PanoControls panoContRef;
	public CameraController cameraContRef;
	public Text textRef;
	
	void Awake() {
		this.enabled = !panoContRef.useTouchControls;
	}
	
	public void SwitchControls() {
		panoContRef.useTouchControls = !panoContRef.useTouchControls;
		if (!panoContRef.useTouchControls) {
			this.enabled = Input.gyro.enabled = true;
			cameraContRef.Init();
		}
		else {
			this.enabled = Input.gyro.enabled = false;
			cameraContRef.End();
			panoContRef.Pan(PanoControls.Originator.GuibuttonDown);
		}
	}
	/*
	void Update() {
		if (Input.gyro.rotationRate.x < -0.1f) {
			panoContRef.Pan(PanoControls.Originator.GuibuttonRight);
		}
		else if (Input.gyro.rotationRate.x > 0.1f) {
			panoContRef.Pan(PanoControls.Originator.GuibuttonLeft);
		}
		
		textRef.text = Input.gyro.rotationRate.ToString("F4");
		textRef.text += "\n" + Input.gyro.enabled.ToString();
		textRef.text += "\n" + Input.acceleration.ToString("F4");
	}
	*/
	
}