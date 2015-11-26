using UnityEngine;
using System.Collections;

public class Switcher : MonoBehaviour {
	
	public void ArChange() {
		if (Application.loadedLevelName == "AR") {
			Application.LoadLevel("panorama");
		}
		else {
			Application.LoadLevel("AR");
		}
	}
	public void Level(string level) {
		Debug.Log("loading:"+level);
		Application.LoadLevel(level);
	}
}
