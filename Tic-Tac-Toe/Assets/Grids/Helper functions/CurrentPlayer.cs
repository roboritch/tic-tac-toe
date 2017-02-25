using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// the current player is a boolean value with X as false and O as true
/// </summary>
public class CurrentPlayer : MonoBehaviour {
	/// <summary>
	/// false is X true is O
	/// </summary>
	private bool currentPlayer = true;
	[SerializeField]
	private Sprite xPlayer, oPlayer;



	public bool getCurrentPlayer() {
		return currentPlayer;
	}
	/// <summary>
	/// changes the current player
	/// </summary>
	/// <returns>the current player</returns>
	public bool changePlayer() {
		currentPlayer = !currentPlayer;
		if (currentPlayer) {
			playerDisplay.sprite = oPlayer;
		}else{
			playerDisplay.sprite = xPlayer;
		}
		return currentPlayer;
	}

	private Image playerDisplay;
	// Use this for initialization
	void Start () {
		playerDisplay = GetComponent<Image>();
		changePlayer();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
