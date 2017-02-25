using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ends the game on esc or button press
/// </summary>
public class EndGame : MonoBehaviour {

	public void endGame() {
		Application.Quit();
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape)) {
			endGame();
		}
	}
}
