using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) == true) {
			LevelManager.instance.flipTheSwitch ();
		}
	}
}
