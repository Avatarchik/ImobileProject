using UnityEngine;
using System.Collections;

public class ShutterEffect : MonoBehaviour {
	
	public float rotationSpeed = 0f;

	// Update is called once per frame
	void Update () {
		transform.Rotate(0f,rotationSpeed * Time.deltaTime,0f);
	}
	void OnGUI () {
		GUILayout.Label("grade/secunda" + rotationSpeed);
	}
}
